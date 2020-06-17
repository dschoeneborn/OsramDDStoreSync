using System;
using System.IO;
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
        private static TXGraylog.TXGraylog graylogClient;

        // App.config settings
        private static string driverPath = "";
        private static string familyPath = "";
        private static int interval = 60000; // 60 seconds

        private static SyncManager syncManager;

        public OsramDDStoreSync()
        {
            log.Info("Init OsramDDStoreSync");
            try
            {
                InitializeComponent();
                if(ConfigurationManager.AppSettings.Get("EnableGraylog") == "true")
                    graylogClient = new TXGraylog.TXGraylog(ConfigurationManager.AppSettings.Get("GraylogHost"),
                        "OsramDriverDataSync",
                        Convert.ToInt32(ConfigurationManager.AppSettings.Get("GraylogPort")));

                // init config from App.config
                InitConfiguration();

                syncManager = new SyncManager(driverPath, familyPath, interval);

            }
            catch (Exception e)
            {
                log.Error("Error by init service", e);
                if(graylogClient != null)
                    graylogClient.Error(e);
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
                throw new Exception("Error by determining configuration", e);
            }
        }

        public void StartManual()
        {
            OnStart(null);
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
            Version syncVersion;
            log.Info("--------Start sync--------");

            try
            {
                syncVersion = syncManager.Sync();
                if(syncVersion > new Version("0.0.0"))
                {
                    log.Info("Successfully updated local db to " + syncVersion.ToString() + "");
                    if (graylogClient != null)
                        graylogClient.Info("Successfully updated local db to " + syncVersion.ToString());
                }
                else
                {
                    if (graylogClient != null)
                        graylogClient.Info("No new Version found while sync");
                }
                
            }
            catch(Exception e)
            {
                log.Error("Error by sync", e);
                if (graylogClient != null)
                    graylogClient.Error(e);
            }
            
            log.Info("--------End sync--------");
        }
    }
}
