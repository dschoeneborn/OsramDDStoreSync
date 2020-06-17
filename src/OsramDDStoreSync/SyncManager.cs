using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OsramDDStoreSync
{
    class SyncManager
    {
        //logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string versionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.ver");
        private static Version localDbVersion;
        private static Version onlineDbVersion;

        private static string driverPath = "";
        private static string familyPath = "";
        private static int interval = 60000; // 60 seconds

        // swagger api endpoints
        private static DdInfosApi ddInfosApiInstance;
        private static DdFileApi ddFileApiInstance;
        private static VersionApi versionInstance;

        public SyncManager(string driverDataPath, string familyDataPath, int timerInterval)
        {
            driverPath = driverDataPath;
            familyPath = familyDataPath;
            interval = timerInterval;

            InitVersionFile();
            InitApiEndpoints();
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
            catch (Exception e)
            {
                throw new Exception("Error by init api endpoints", e);
            }
        }

        public Version Sync()
        {
            Version syncVersion = new Version("0.0.0");

            try
            {
                if (DbVersionIsNewer())
                {
                    GetDriverData();

                    GetFamilyData();

                    syncVersion = UpdateLocalDbVersion();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error by sync", e);
            }

            return syncVersion;
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
            catch (Exception e)
            {
                throw new Exception("Error by checking onlineDbVersion", e);
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
                FileStream file = new FileStream(familyPath + "devices.xml", FileMode.Create, FileAccess.Write);

                response.CopyTo(file);

                file.Close();
                log.Info("New family data written");

            }
            catch (Exception e)
            {
                throw new Exception("Error by getting family data", e);
            }
        }

        private Version UpdateLocalDbVersion()
        {
            File.WriteAllText(versionFilePath, onlineDbVersion.ToString());
            localDbVersion = onlineDbVersion;

            return localDbVersion;
        }
    }
}
