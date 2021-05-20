using System;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System.Threading;
using AventStack.ExtentReports.Reporter;


namespace UnitTestProject1.src
{



    [TestFixture]
    // [TestFixture("chrome")]
    // [Parallelizable(ParallelScope.Fixtures)]
    class ConsoleTestRunner
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        //  private static IWebDriver driver;
        private ExtentHtmlReporter htmlReporter;
        private string browser;
        private BrowerType _browserType;
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //Enum for browserType
        public enum BrowerType
        {
            chrome,
            ie
        }


        DriverManager driverManager = new DriverManager();
        VerifyAssertion verifyAssertion = new VerifyAssertion();
        
        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");



        
        [OneTimeSetUp]
        public void SetupReporting()
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



        [SetUp]
        public void InitBrowser()
        {

            //   var browser = TestContext.Parameters.Get("browser");
            //  System.Console.WriteLine("The browser parameter is= "+ browser);


            //Get the value from NUnit-console --params 
            //e.g. nunit3-console.exe --params:Browser=Firefox \SeleniumNUnitParam.dll
            //If nothing specified, test will run in Chrome browser
            var browserType = TestContext.Parameters.Get("browser", "ie");
            //Parse the browser Type, since its Enum
            _browserType = (BrowerType)Enum.Parse(typeof(BrowerType), browserType);
            //Pass it to browser
            driverManager.ChooseDriverInstance(_browserType);

        }




         //    [Test]
        public void PassingTest()
        {


            Console.WriteLine("Entering first case");

            //  driverManager.driverStore();
            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);

            Console.WriteLine("Started logs for first case");

            test = extent.CreateTest("First Passing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Passing Test");

            test.Log(Status.Info, "Assertion  First Passing Test ");

            test.Log(Status.Info, "Website is opened in First Passing Test");

            Console.WriteLine("Completed logs for first  case");

            verifyAssertion.checkAssertionTrue();
            Console.WriteLine("Completed assertion for first case");

        }



        //   [Test]
        public void FailingTest()
        {
            Console.WriteLine("Entering second case");
            // driverManager.driverStore();

            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);

            Console.WriteLine("Started logs for failing case");


            test = extent.CreateTest("First Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Failing Test");

            test.Log(Status.Info, "Assertion  First Failing Test ");

            test.Log(Status.Info, "Website is opened in First Failing Test");

            Console.WriteLine("Completed logs for failing  case");

            verifyAssertion.checkAssertionFalse();

            Console.WriteLine("Completed assertion for failing case");

        }


        [TearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("It is going in TearDown box");

        }


        [OneTimeTearDown]
        public void GenerateReport()
        {
            Console.WriteLine("It is going in OneTimeTearDown box");
            //      ExtentManager.Instance.Flush();
            extent.Flush();



        }

    }
}

