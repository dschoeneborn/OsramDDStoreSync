using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DummyOsramDDStoreSync
{
    class Program
    {
        private static DdInfosApi ddInfosApiInstance;
        private static DdFileApi ddFileApiInstance;

        private static readonly String path = "C:\\Users\\Dennis\\Desktop\\Driver\\";

        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ddInfosApiInstance = new DdInfosApi();

            var driverDataList = ddInfosApiInstance.GetDdInfo();

            foreach(var driverData in driverDataList)
            {
                if(!File.Exists(path + driverData.XmlRef))
                {
                    ddFileApiInstance = new DdFileApi();

                    string xmlref = driverData.XmlRef;
                    string format = null;

                    Stream response2 = ddFileApiInstance.GetDdfileByRef(xmlref, format);
                    FileStream file = new FileStream(path + driverData.XmlRef, FileMode.Create, System.IO.FileAccess.Write);


                    response2.CopyTo(file);
                }
            }

            Console.ReadKey();
        }
    }
}
