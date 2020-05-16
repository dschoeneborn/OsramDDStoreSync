﻿using System;
using System.IO;
using System.Net;
using System.ServiceProcess;
using System.Timers;
using IO.Swagger.Api;
using System.Configuration;

namespace OsramDDStoreSync
{
    public partial class OsramDDStoreSync : ServiceBase
    {
        //logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // App.config settings
        private static string driverPath = "";
        private static string familyPath = "";
        private static int interval = 60000; // 60 seconds

        // to manage version
        private string versionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.ver");
        private static Version localDbVersion;
        private static Version onlineDbVersion;

        // swagger api endpoints
        private static DdInfosApi ddInfosApiInstance;
        private static DdFileApi ddFileApiInstance;
        private static VersionApi versionInstance;

        public OsramDDStoreSync()
        {
            log.Info("Init OsramDDStoreSync");
            try
            {
                InitializeComponent();

                // init config from App.config
                InitConfiguration();

                // init api endpoints
                InitApiEndpoints();

                // init versionFile if not exist
                InitVersionFile();
            }
            catch (Exception e)
            {
                log.Error("Error by init service", e);
            }
        }

        private void InitConfiguration()
        {
            try
            {
                // get driver data path
                driverPath = ConfigurationManager.AppSettings.Get("DriverDataPath");
                if (!driverPath.EndsWith("\\"))
                {
                    driverPath += "\\";
                }
                log.Info("DriverDataPath is set to " + driverPath);
                Directory.CreateDirectory(driverPath);

                // get family data path
                familyPath = ConfigurationManager.AppSettings.Get("FamilyDataPath");
                if (!familyPath.EndsWith("\\"))
                {
                    familyPath += "\\";
                }
                log.Info("FamilyDataPath is set to " + familyPath);
                Directory.CreateDirectory(familyPath);

                // get timer intervall
                interval = Int32.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
                log.Info("Interval is set to " + interval + "ms");
            }
            catch(Exception e)
            {
                throw new Exception("Error by init configuration", e);
            }
        }

        private void InitApiEndpoints()
        {
            try
            {
                // enable SSL/TLS
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                versionInstance = new VersionApi();
                ddInfosApiInstance = new DdInfosApi();
                ddFileApiInstance = new DdFileApi();
            }
            catch(Exception e)
            {
                throw new Exception("Error by init api endpoints", e);
            }
        }

        private void InitVersionFile()
        {
            if (!File.Exists(versionFilePath))
            {
                log.Warn("VersionFile " + versionFilePath + " does not exist. Try to create.");


                if (!Directory.Exists(Path.GetDirectoryName(versionFilePath)))
                {
                    log.Info("Try to create directory " + Path.GetDirectoryName(versionFilePath));
                    Directory.CreateDirectory(Path.GetDirectoryName(versionFilePath));
                }

                File.WriteAllText(versionFilePath, "0.0.0");
            }

            //read version file
            localDbVersion = new Version(File.ReadAllText(versionFilePath));
            log.Info("LocalDbVersion is set to " + localDbVersion);
        }

        protected override void OnStart(string[] args)
        {
            log.Info("Starting OsramDDStoreSync");

            log.Info("Trying to init Timer");
            Timer timer = new Timer
            {
                Interval = interval
            };
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
            log.Info("Timer successfully set to 60sec");

            // First call
            OnTimer(null, null);
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            log.Info("--------Start sync--------");
            if(DbVersionIsNewer())
            {
                try
                {
                    GetDriverData();

                    GetFamilyData();

                    UpdateLocalDbVersion();
                }
                catch(Exception e)
                {
                    log.Error("Error by sync", e);
                }
                
            }
            log.Info("--------End sync--------");
        }

        private bool DbVersionIsNewer()
        {
            bool isNewer = false;

            log.Info("Start checking database verison");

            try
            {
                // api returns "1.0.0" but i need 1.0.0
                string versionString = versionInstance.GetDatabaseVersion().Replace("\"", "");
                onlineDbVersion = new Version(versionString);

                log.Info("localVersion: " + localDbVersion + "; onlineVersion: " + onlineDbVersion);

                if (onlineDbVersion > localDbVersion)
                {
                    log.Info("New database version detected: " + onlineDbVersion);

                    isNewer = true;
                }
                else if (onlineDbVersion < localDbVersion)
                {
                    log.Warn("Online database version is lower than current local version");
                }
                else
                {
                    log.Info("Online database Version is equals local one");
                }
            }
            catch(Exception e)
            {
                log.Error("Error by checking onlineDbVersion", e);
            }

            log.Info("End checking Database verison");
            return isNewer;
        }

        private void GetDriverData()
        {
            try
            {
                log.Info("Start looking for new driver data");
                
                var driverDataList = ddInfosApiInstance.GetDdInfo();

                foreach (var driverData in driverDataList)
                {
                    if (!File.Exists(driverPath + driverData.XmlRef))
                    {
                        log.Info("New driver data for " + driverData.XmlRef + " found");

                        string xmlref = driverData.XmlRef;
                        string format = null;

                        Stream response = ddFileApiInstance.GetDdfileByRef(xmlref, format);
                        FileStream file = new FileStream(driverPath + driverData.XmlRef, FileMode.Create, FileAccess.Write);

                        response.CopyTo(file);
                        file.Close();
                        log.Info("New driver data for " + driverData.XmlRef + " written");
                    }
                }
                log.Info("End looking for new driver data");
            }
            catch (Exception e)
            {
                throw new Exception("Error by getting driver data", e);
            }
        }

        private void GetFamilyData()
        {
            try
            {
                log.Info("Downloading new Family Data");

                Stream response = ddFileApiInstance.GetFamiliyFile();
                FileStream file = new FileStream(familyPath + "Family.xml", FileMode.Create, FileAccess.Write);

                response.CopyTo(file);

                file.Close();
                log.Info("New family data written");
   
            }
            catch (Exception e)
            {
                throw new Exception("Error by getting family data", e);
            }
        }

        private void UpdateLocalDbVersion()
        {
            File.WriteAllText(versionFilePath, onlineDbVersion.ToString());
        }
    }
}
