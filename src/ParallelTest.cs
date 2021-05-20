using NUnit.Framework;
using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using System.Threading;
using UnitTestProject1.src;
using AventStack.ExtentReports.Reporter;

namespace UnitTestProject1
{
     [TestFixture("chrome")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelTest
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        private static IWebDriver _driver;
        private ExtentHtmlReporter htmlReporter;
        private string browser;
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();


        DriverManager driverManager = new DriverManager();
        VerifyAssertion verifyAssertion = new VerifyAssertion();
        
        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");




        public ParallelTest(string browser)
        {
            this.browser = browser;
        }

        [OneTimeSetUp]
        public void SetupReporting()
        {
            //  driverManager.extentChromeMethod();

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



        [SetUp]
        public void InitBrowser()
        {
            driverManager.driverStoreChrome();

        }



        [Test]
        public void PassingTest()
        {


            Console.WriteLine("Entering first case");

            //  driverManager.driverStore();
            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);

            Console.WriteLine("Started logs for first case");

            test = extent.CreateTest("First Passing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Passing Test");

            test.Log(Status.Pass, "Assertion  First Passing Test ");

            test.Log(Status.Info, "Website is opened in First Passing Test");

            Console.WriteLine("Completed logs for first  case");

            verifyAssertion.checkAssertionTrue();
            Console.WriteLine("Completed assertion for first case");

        }



        [Test]
        public void FailingTest()
        {
            Console.WriteLine("Entering second case");
            // driverManager.driverStore();

            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);



            Console.WriteLine("Started logs for failing case");


            test = extent.CreateTest("First Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Failing Test");

            test.Log(Status.Fail, "Assertion  First Failing Test ");

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

            extent.Flush();



        }
    }
}






