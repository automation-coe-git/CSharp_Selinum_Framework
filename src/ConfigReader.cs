using NUnit.Framework;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class ConfigReader
    {


        //  [Test]
        public static string configurationReader()
        {

            var browser = ConfigurationManager.AppSettings["browser"];
            var url = ConfigurationManager.AppSettings["url"];



            Console.WriteLine("My browser is= " + browser);
            Console.WriteLine("My url is= " + url);



            return browser;
        }




    }
}
