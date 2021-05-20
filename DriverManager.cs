using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Threading;
using static UnitTestProject1.src.ConsoleTestRunner;

namespace UnitTestProject1
{
    class DriverManager
    {
        private IWebDriver driver;
        private string browser;
        private BrowerType _browserType;
        private static ExtentReports extent;
        private static ExtentTest test;
        private static IWebDriver _driver;
        private ExtentHtmlReporter htmlReporter;
        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");

        private ExtentHtmlReporter chromehtmlReporter;
        private ExtentHtmlReporter iehtmlReporter;


        public DriverManager()
        {

        }

        public DriverManager(string browser)
        {
            this.browser = browser;
        }

        public dynamic GetBrowserOptions(string browser)
        {
            if (browser == "chrome")
                return new ChromeDriver();
            if (browser == "ie")
                return new InternetExplorerDriver();

            return new ChromeDriver();


        }



        public void goToPage(String test_url)
        {
            Console.WriteLine("Entring the Url method");
            if (test_url != null)
            {

                Thread.Sleep(1000);

                //   driver = new ChromeDriver();
                try
                {
                    driver.Navigate().GoToUrl(test_url);


                    Console.WriteLine("Selected the url");
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Exception is = " + e.ToString());
                    throw;
                }

            }
            Console.WriteLine("Test url is null");
        }

        public void goToPage(String test_url, IWebDriver driver)
        {


            Console.WriteLine("Entring the Url method" + driver);


            /*
            if (browser == "chrome")
            {
                driver.Navigate().GoToUrl(test_url);

            }
            else if (browser == "ie")
            {
                driver.Navigate().GoToUrl(test_url);
                

            }
           */


            driver.Navigate().GoToUrl(test_url);
            Console.WriteLine("Selected the url");

        }





        public void extentFilesMethod(string browser)
        {


            switch (browser)
            {

                case "chrome":
                    htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html");
                    string sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html";
                    System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
                    if (fi.Exists)
                    {

                        fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\Extentreport-" + timeStamp + ".html");

                        Console.WriteLine(" Chrome File Renamed!!");

                    }
                    Console.WriteLine("The Extent Report is generated in chrome folder.");
                    break;
                case "ie":
                    htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html");
                    sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html";
                    fi = new System.IO.FileInfo(sourceFile);
                    if (fi.Exists)
                    {

                        fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\Extentreport-" + timeStamp + ".html");

                        Console.WriteLine(" IE File Renamed!!");

                    }
                    Console.WriteLine("The Extent Report is generated in ie folder.");
                    break;
                case "firefox":
                    htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\firefox\index.html");
                    break;
                default:
                    htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\parallel\index.html");
                    break;
            }


            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            Console.WriteLine("The Extent Report is generated.");



        }



        public void extentChromeMethod()
        {
            htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html");
            string sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html";
            System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            if (fi.Exists)
            {

                fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\Extentreport-" + timeStamp + ".html");

                Console.WriteLine("File Renamed!!");
            }

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            Console.WriteLine("The Extent Report is generated.");



        }



        public void extentIEMethod()
        {
            Console.WriteLine(" Onetime Setup for IE!!");
            htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html");
            string sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html";
            System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            if (fi.Exists)
            {
                Console.WriteLine(" The file exists-Onetime Setup for IE!!");
                fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\Extentreport-" + timeStamp + ".html");

                Console.WriteLine(" IE File Renamed!!");
            }



            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            Console.WriteLine("The Extent Report is generated.");


        }



        public void driverStore(string browser)
        {
            //  var browser = ConfigurationManager.AppSettings["browser"];
            //  Console.WriteLine("My current browser is= " + browser);

            //   var url = ConfigurationManager.AppSettings["url"];
            // Console.WriteLine("My current url is= " + url);

            //   var browser1 = ConfigurationManager.AppSettings["browser1"];
            //  Console.WriteLine("My current browser is= " + browser1);

            //  var browser2 = ConfigurationManager.AppSettings["browser2"];
            //  Console.WriteLine("My current browser is= " + browser2);

            switch (browser)
            {

                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new InternetExplorerDriver();
                    break;
            }




        }


        public void driverStoreChrome()
        {


            var browser1 = ConfigurationManager.AppSettings["browser1"];
            Console.WriteLine("My current browser is= " + browser1);




            if (browser1.Equals("chrome"))
            {

                driver = new ChromeDriver();

            }
            else
            {
                Console.WriteLine("Please make browser1 to chrome");
            }


        }


        public void driverStoreIE()
        {


            var browser2 = ConfigurationManager.AppSettings["browser2"];
            Console.WriteLine("My current browser is= " + browser2);


            if (browser2.Equals("ie"))
            {
                Console.WriteLine("It is enetering DM for IE!!!!");
                driver = new InternetExplorerDriver();
                Console.WriteLine("It is selecting DM for IE!!!!");
            }
            else
            {
                Console.WriteLine("Please make browser2 to ie");
            }




        }


        public void driverClose()
        {
            driver.Close();

        }


        public void driverQuit()
        {
            driver.Quit();

        }



        public void ChooseDriverInstance(BrowerType browserType)
        {
            if (browserType == BrowerType.chrome)
                driver = new ChromeDriver();
            else if (browserType == BrowerType.ie)
            {
                driver = new InternetExplorerDriver();
            }

        }
    }

}