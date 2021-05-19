using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BOKF.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using FluentAssertions.Execution;
using FluentAssertions;

namespace BOKF
{

    [TestFixture("chrome")]
    //[TestFixture("firefox")]

    class Program
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest test;
        private string jsonFileData;
        private string testcasename;
        private string jsonFilePath;
        private string projectPath;
        private IWebDriver webDriver;
        private string browser;

        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");
        ThreadLocal<ExtentTest> extenttest = new ThreadLocal<ExtentTest>();
        static public void Main()
        {

            Console.WriteLine("Main Method");
        }

        [OneTimeSetUp]
        public void SetupReporting()
        {
            projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            htmlReporter = new ExtentHtmlReporter(projectPath+"\\Reports" + timeStamp + "extentreport1.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        public Program()
        {

        }
        public Program(string browser)
        {
            this.browser = browser;
        }
        [SetUp]
        public void InitBrowser()
        {

            testcasename = NUnit.Framework.TestContext.CurrentContext.Test.Name;

            jsonFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.." + "\\" + "TestData" + "\\" + testcasename + ".json"));
            jsonFileData = File.ReadAllText(jsonFilePath);
            BaseClass driver = new BaseClass();
        }

        [Test]
        public void testcase1()
        {
            test = extent.CreateTest(this.testcasename);
            JsonUtilities j = new JsonUtilities();
            var expectedData = j.getJsonDataWithListObject<JsonUtilities.Result>("responseData.results", this.jsonFileData);
            var jsonFileData1 = File.ReadAllText("C:/Users/Ashrith/source/repos/SeleniumFramwork/TestData/FailingTest.json");
            var actualData = j.getJsonDataWithListObject<JsonUtilities.Result>("responseData.results", jsonFileData1);
            using (new AssertionScope())
            {
                for (int i = 0; i < expectedData.Count; i++)
                {

                    expectedData[i].Should().BeEquivalentTo(actualData[i]);
                }
            }

            test.Log(Status.Info, "both the list items Matched");
        }

        [Test]
        public void Testcase2()
        {
            test = extent.CreateTest(this.testcasename);
            JsonUtilities j = new JsonUtilities();
            var expectedData = j.getJsonDataWithListObject<JsonUtilities.Cursor>("responseData.results", this.jsonFileData);
            var jsonFileData1 = File.ReadAllText("C:/Users/Ashrith/source/repos/SeleniumFramwork/TestData/FailingTest.json");
            var actualData = j.getJsonDataWithListObject<JsonUtilities.Cursor>("responseData.results", jsonFileData1);
            using (new AssertionScope())
            {
                for (int i = 0; i < expectedData.Count; i++)
                {

                    expectedData[i].Should().BeEquivalentTo(actualData[i]);
                }

            }
            test.Log(Status.Info, "both the list items Matched");
            j.SerializeJasonData(this.jsonFileData, this.jsonFilePath, 9876543);
            try
            {
                Assert.IsTrue(true);
                test.Pass("Assertion passed");
                test.Pass("Assertion passed");
                test.Pass("Assertion passed");


            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                test.Log(Status.Fail, stackTrace + errorMessage);
            }
 
        }

        [OneTimeTearDown]

        public void GenerateReport()
        {
            extent.Flush();
        }
    }
}
