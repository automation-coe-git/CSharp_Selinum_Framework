using System;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System.Threading;
using UnitTestProject1.src;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace UnitTestProject1
{     
          [TestFixture("ie")]

    // [Parallelizable(ParallelScope.Fixtures)]
    class IEParallelTest
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


        // string workingDirectory = Environment.CurrentDirectory;
        // string workingDirectory = Directory.GetCurrentDirectory();
       // string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
      //  string projectDirectoryBin = Directory.GetParent(workingDirectory).Parent.FullName;
        
      //  string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;




        public IEParallelTest(string browser)
            {
                this.browser = browser;
            }

            [OneTimeSetUp]
            public void SetupReporting()
            {
            //driverManager.extentIEMethod();
            



            Console.WriteLine(" Onetime Setup for IE!!");
                 htmlReporter = new ExtentHtmlReporter(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html");
                  string sourceFile = @"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\index.html";
               //   htmlReporter = new ExtentHtmlReporter(@"projectDirectory\Reports\ie\index.html");
             //     string sourceFile = @"projectDirectory\Reports\ie\index.html";
                  System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            if (fi.Exists)
            {
                Console.WriteLine(" The file exists-Onetime Setup for IE!!");
                //  fi.MoveTo(@"projectDirectory\Reports\ie\Extentreport-" + timeStamp + ".html");
                fi.MoveTo(@"D:\SlkSeleniumFramework\TestProjectSample\TestProjectCL\UnitTest\UnitTestProject1\Reports\ie\Extentreport-" + timeStamp + ".html");

                Console.WriteLine(" IE File Renamed!!");
            }



            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            Console.WriteLine("The Extent Report is generated.");



        }



            [SetUp]
            public void InitBrowser()
            {
            driverManager.driverStoreIE();
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

            Console.WriteLine("Completed logs for second case");

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

            
            Console.WriteLine("Started logs for second case");

            test = extent.CreateTest("First Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Failing Test");

           test.Log(Status.Fail, "Assertion  First Failing Test ");

            test.Log(Status.Info, "Website is opened in First Failing Test");

            Console.WriteLine("Completed logs for second case");

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
