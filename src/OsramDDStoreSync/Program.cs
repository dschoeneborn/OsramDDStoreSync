using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OsramDDStoreSync
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main(string[] args)
        {
            if (System.Environment.UserInteractive)
            {
                string parameter = string.Concat(args);
                try
                {
                    switch (parameter)
                    {
                        case "":
                            var service = new OsramDDStoreSync();
                            service.StartManual();
                            Console.WriteLine("Press any key to stop the program");
                            Console.Read();
                            service.Stop();
                            break;
                        case "--install":
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            break;
                        case "--uninstall":
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                            break;
                        default:
                            Console.WriteLine("Argument not found");
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("(un)install failed", e);
                }
                
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new OsramDDStoreSync()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
