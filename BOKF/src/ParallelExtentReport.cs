using System;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System.Threading;
using AventStack.ExtentReports.Reporter;


namespace UnitTestProject1.src
{

    [TestFixture("chrome")]
    [TestFixture("ie")]
    class ParallelExtentReport
    {

        private static ExtentReports extent1 = new ExtentReports();
        private static ExtentReports extent2 = new ExtentReports();
        private static ExtentTest test;
        private static IWebDriver _driver;
        // private ExtentHtmlReporter chromehtmlReporter;
        //  private ExtentHtmlReporter iehtmlReporter;
         private ExtentHtmlReporter htmlReporter;
        private string browser;
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        // ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();
        static dynamic _browser = null;
        static dynamic _reporter = null;


        DriverManager driverManager = new DriverManager();
        VerifyAssertion verifyAssertion = new VerifyAssertion();

        ExtentLogs extentlogs = new ExtentLogs();
        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");




        public ParallelExtentReport(string browser)
        {
            this.browser = browser;
        }

        public ParallelExtentReport()
        {

        }





        [OneTimeSetUp]
        public void SetupReporting()
        {
           // this.browser = browser;
            Console.WriteLine("It is going in OneTimeSetUp box"+browser);
            // _reporter = GetExtentOptions();
            GetExtentOptions();
            //  Console.WriteLine("The dynamic reporter is" + _reporter);
            //  driverManager.extentChromeMethod();

            //  dynamic _reporter = GetExtentOptions(browser);
            // Console.WriteLine("It is going in OneTimeSetUp box");
        }



        [SetUp]
        public void InitBrowser()
        {

            //  driverManager.extentFilesMethod(browser);
            _browser = driverManager.GetBrowserOptions(browser);
            // driverManager.driverStore(browser);
            // driverManager.driverStoreChrome();

        }




          [Test]
        public void PassingTest()
        {

            Console.WriteLine("The dynamic browser driver is" + _browser);

            Console.WriteLine("Entering first case");

            //  driverManager.driverStore();
            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url, _browser);
            //    driverManager.goToPage(test_url);

            Console.WriteLine("Started logs for first case .");
            if(browser == "chrome")
            {
                test = extent1.CreateTest(browser + ": First Passing Test in Chrome ").Info("Test Started");
            }
            else if(browser == "ie")
            {
                test = extent2.CreateTest(browser + ": First Passing Testin IE").Info("Test Started");
            }
            
            test.Log(Status.Info, "Url is entered in First Passing Test");
            test.Log(Status.Pass, "Assertion  First Passing Test ");
            test.Log(Status.Info, "Website is opened in First Passing Test");
            Console.WriteLine("Completed logs for first  case");



            //  extentlogs.logKeeperMethod(browser);


            verifyAssertion.checkAssertionTrue();
            Console.WriteLine("Completed assertion for first case");

        }



            [Test]
        public void FailingTest()
        {
            Console.WriteLine("Entering second case");

            Console.WriteLine("The dynamic browser driver is" + _browser);
            // driverManager.driverStore();

            String test_url = "http://www.facebook.com";

            //    driverManager.goToPage(test_url);

            driverManager.goToPage(test_url, _browser);

            Console.WriteLine("Started logs for failing case");


          //  test = extent.CreateTest(browser + ": First Failing Test").Info("Test Started");

            if (browser == "chrome")
            {
                test = extent1.CreateTest(browser + ": First Failing Test in Chrome ").Info("Test Started");
            }
            else if (browser == "ie")
            {
                test = extent2.CreateTest(browser + ": First Failing Testin IE").Info("Test Started");
            }

            test.Log(Status.Info, "Url is entered in First Failing Test");

            test.Log(Status.Fail, "Assertion  First Failing Test ");

            test.Log(Status.Info, "Website is opened in First Failing Test");

            Console.WriteLine("Completed logs for failing  case");

            verifyAssertion.checkAssertionFalse();

            Console.WriteLine("Completed assertion for failing case");



        }



      //  [Test]
        public void SecondPassingTest()
        {

            Console.WriteLine("The dynamic browser driver is" + _browser);

            Console.WriteLine("Entering second case");

            //  driverManager.driverStore();
            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url, _browser);
            //    driverManager.goToPage(test_url);

            Console.WriteLine("Started logs for second case .");
            if (browser == "chrome")
            {
                test = extent1.CreateTest(browser + ": Seond Passing Test in Chrome ").Info("Test Started");
            }
            else if (browser == "ie")
            {
                test = extent2.CreateTest(browser + ": Second Passing Testin IE").Info("Test Started");
            }

            test.Log(Status.Info, "Url is entered in Second Passing Test");
            test.Log(Status.Pass, "Assertion  Second Passing Test ");
            test.Log(Status.Info, "Website is opened in Second Passing Test");
            Console.WriteLine("Completed logs for second  case");



            //  extentlogs.logKeeperMethod(browser);


            verifyAssertion.checkAssertionTrue();
            Console.WriteLine("Completed assertion for first case");

        }





        public void GetExtentOptions()
        {
           // this.browser = browser;
            Console.WriteLine("Entered the extent method for: " + browser);

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
        
                    default:
                    htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\parallel\index.html");
                    break;


                 

            }

            if (browser == "chrome")
            {
                  extent1.AttachReporter(htmlReporter);
            }
            else if (browser == "ie")
            {
                 extent2.AttachReporter(htmlReporter);
            }


            //  extent.AttachReporter(htmlReporter);
            //  extent.Flush();




            Console.WriteLine("The Extent Report is generated."+browser);
        }



/*

        private dynamic GetExtentOptions()
        {

            switch (browser)
            {

                case "chrome":
                    chromehtmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html");
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
                    iehtmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html");
                    sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html";
                    fi = new System.IO.FileInfo(sourceFile);
                    if (fi.Exists)
                    {
                        Thread.Sleep(1000);
                        fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\Extentreport1-" + timeStamp + ".html");

                        Console.WriteLine(" IE File Renamed!!");

                    }
                    Console.WriteLine("The Extent Report is generated in ie folder.");
                    break;

                default:
                    chromehtmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html");
                    sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\index.html";
                    fi = new System.IO.FileInfo(sourceFile);
                    if (fi.Exists)
                    {

                        fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\chrome\Extentreport-" + timeStamp + ".html");

                        Console.WriteLine(" Chrome File Renamed!!");

                    }
                    Console.WriteLine("The Extent Report is generated in chrome folder.");
                    break;


            }




            extent = new ExtentReports();


            if (browser == "chrome")
            {
                extent.AttachReporter(chromehtmlReporter);
                return chromehtmlReporter;
            }
            else if (browser == "ie")
            {
                extent.AttachReporter(iehtmlReporter);
                return iehtmlReporter;

            }
            else
            {
                Console.WriteLine("The reporter is not attached.");
                return chromehtmlReporter;
            }

        }


*/




        [TearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("It is going in TearDown box");



        }


        [OneTimeTearDown]
        public void GenerateReport()
        {
            Console.WriteLine("It is going in OneTimeTearDown box");
            //  extent = new ExtentReports();
            //  extent.AttachReporter(htmlReporter);

            // extent.Flush();

            if (browser == "chrome")
            {
                 extent1.Flush();
            }
            else if (browser == "ie")
            {
                extent2.Flush();
            }

            Console.WriteLine(" Extent Flush is completed");

        }
/*
        public void extentFlush()
        {
            extent.Flush();
        }
*/

          
    }

    
}
