using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using UnitTestProject1.src;

namespace UnitTestProject1
{

 //  [TestFixture("chrome")]
    class ExtentManager
    {

        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();


        // private IWebDriver driver;
        private ExtentReports extent;
        private ExtentHtmlReporter htmlReporter;
        private ExtentTest test;
        //   ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();

        private string browser;




        DriverManager driverManager = new DriverManager();
        VerifyAssertion verifyAssertion = new VerifyAssertion();
     //   ExtentFactory extentFactory = new ExtentFactory();
        ExtentLogs extentLogs = new ExtentLogs();
        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");


        // ArrayList browserList;


        public ExtentManager()
        {

        }
        public ExtentManager(string browser)
        {
            this.browser = browser;
        }





        [OneTimeSetUp]
        public void SetupReporting()
        {
            //  var browser = ConfigurationManager.AppSettings["browser"];
            //  Console.WriteLine("My onetime current browser is= " + browser);


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
            //  driverManager.driverStore();

        }





        //   [Test]
        public void PassingTest()
        {


            Console.WriteLine("Entering first case");

            //  driverManager.driverStore();
            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);



            test = extent.CreateTest("First Passing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Passing Test");

            test.Log(Status.Info, "Assertion  First Passing Test ");

            test.Log(Status.Info, "Website is opened in First Passing Test");

            verifyAssertion.checkAssertionTrue();

            Console.WriteLine("1-Facebook Page opened");

            

            extentLogs.addLogsInExtentFirstPassingTest();


        }



        // [Test]
        public void FailingTest()
        {
            Console.WriteLine("Entering second case");
            // driverManager.driverStore();

            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);


            test = extent.CreateTest("First Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Failing Test");

            test.Log(Status.Info, "Assertion  First Failing Test ");

            test.Log(Status.Info, "Website is opened in First Failing Test");

            verifyAssertion.checkAssertionFalse();

            Console.WriteLine("2-Facebook Page opened");

            extentLogs.addLogsInExtentFirstFailingTest();




        }





        // [Test]
        public void SecondPassingTest()
        {
            Console.WriteLine("Entering third case");

            // driverManager.driverStore();
            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);


            test = extent.CreateTest("Second Passing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in Second Passing Test");

            test.Log(Status.Info, "Assertion  Second Passing Test ");

            test.Log(Status.Info, "Website is opened in Second Passing Test");

            verifyAssertion.checkAssertionTrue();

            Console.WriteLine("3-Facebook Page opened");

            
            extentLogs.addLogsInExtentSecondPassingTest();




        }



        //   [Test]
        public void SecondFailingTest()
        {
            Console.WriteLine("Entering second failed case");
            //  driverManager.driverStore();

            String test_url = "http://www.facebook.com";

            driverManager.goToPage(test_url);



            test = extent.CreateTest("Second Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in Second Failing Test");

            test.Log(Status.Info, "Assertion  Second Failing Test ");

            test.Log(Status.Info, "Website is opened in Second Failing Test");

            verifyAssertion.checkAssertionFalse();

            Console.WriteLine("4-Facebook Page opened");
            

            extentLogs.addLogsInExtentSecondFailingTest();



        }






        /*
                [Test]
                public void CaptureScreenshot()
                {
                    test = extent.CreateTest("CaptureScreenshot");     
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl("http://www.automationtesting.in");
                    string title = driver.Title;
                    Assert.AreEqual("Home - Automation Test", title);
                    test.Log(Status.Pass, "Test Passed");
                }
        */





        /*
        publicstaticstringTakeScreenshot()
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string path = path1 + "Screenshot\\" + Utility.RandomString(4, true) + ".png";
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;

            //Call method will return a path as string.
            string path = LoginPage.GetShot();
            //Pass this path in the ”AddScreenCaptureFromPath”
            scenario.AddScreenCaptureFromPath(path);
*/


        [TearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("It is going in TearDown box");
            /*
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
*/
            //    driverManager.driverClose();
            //    dm.driverQuit();
            //    driver.close();
            //     driver.Quit();

            /*
           var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                string screenShotPath = GetScreenshot.Capture(driver, "ScreenShotName");
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromBase64String(screenShotPath));
            }
            
            .*/



            // extent.EndTest(test);                                                                                                                                                                                                                                                                                                                                                                                                            extent.EndTest(test);

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


