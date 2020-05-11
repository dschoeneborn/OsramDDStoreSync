using System;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string path = "";
        private static int interval = 60000; // 60 seconds

        private static DdInfosApi ddInfosApiInstance;
        private static DdFileApi ddFileApiInstance;

        public OsramDDStoreSync()
        {
            InitializeComponent();
            try
            {
                path = ConfigurationManager.AppSettings.Get("DriverDataPath");
                if (!path.EndsWith("\\"))
                {
                    path += "\\";
                }


                interval = Int32.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
            }
            catch (Exception e)
            {
                log.Error("Error by reading configuration", e);
            }
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
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            try
            {
                log.Info("Start looking for new driver data");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                ddInfosApiInstance = new DdInfosApi();

                var driverDataList = ddInfosApiInstance.GetDdInfo();

                foreach (var driverData in driverDataList)
                {
                    if (!File.Exists(path + driverData.XmlRef))
                    {
                        log.Info("New driver data for " + driverData.XmlRef + " found");

                        ddFileApiInstance = new DdFileApi();

                        string xmlref = driverData.XmlRef;
                        string format = null;

                        Stream response2 = ddFileApiInstance.GetDdfileByRef(xmlref, format);
                        FileStream file = new FileStream(path + driverData.XmlRef, FileMode.Create, System.IO.FileAccess.Write);


                        response2.CopyTo(file);
                        log.Info("New driver data for " + driverData.XmlRef + " written");
                    }
                }
                log.Info("End looking for new driver data");
            }
            catch(Exception e)
            {
                log.Error("Error by getting driver data", e);
            }
            
        }



        protected override void OnStop()
        {
            
        }
    }
}
