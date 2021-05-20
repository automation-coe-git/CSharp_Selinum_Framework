using AventStack.ExtentReports;
using System;


namespace UnitTestProject1.src
{
    public class ExtentLogs
    {
        private static ExtentTest test;
        private static ExtentReports extent;


        public void logKeeperMethod(string browser)
        {

            switch (browser)
            {

                case "chrome":
                    Console.WriteLine("Started logs for first case in chrome");

                    test.Log(Status.Info, "Url is entered in First Passing Test");
                    test.Log(Status.Pass, "Assertion  First Passing Test ");
                    test.Log(Status.Info, "Website is opened in First Passing Test");
                    Console.WriteLine("Completed logs for first  case");
                    break;
                case "ie":
                    Console.WriteLine("Started logs for first case in ie");

                    test = extent.CreateTest("First Passing Test").Info("Test Started");

                    test.Log(Status.Info, "Url is entered in First Passing Test");

                    test.Log(Status.Pass, "Assertion  First Passing Test ");

                    test.Log(Status.Info, "Website is opened in First Passing Test");

                    Console.WriteLine("Completed logs for first  case");

                    break;
                    
                    default:
                    Console.WriteLine("Started logs for first case");

                    test = extent.CreateTest("First Passing Test").Info("Test Started");

                    test.Log(Status.Info, "Url is entered in First Passing Test");

                    test.Log(Status.Pass, "Assertion  First Passing Test ");

                    test.Log(Status.Info, "Website is opened in First Passing Test");

                    Console.WriteLine("Completed logs for first  case");

                    break;
            }
        }


        public void addLogsInExtentFirstPassingTest()
        {
            test = extent.CreateTest("First Passing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Passing Test");

            test.Log(Status.Info, "Assertion  First Passing Test ");

            test.Log(Status.Info, "Website is opened in First Passing Test");

        }



        public void addLogsInExtentSecondPassingTest()
        {
            test = extent.CreateTest("Second Passing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in Second Passing Test");

            test.Log(Status.Info, "Assertion  Second Passing Test ");

            test.Log(Status.Info, "Website is opened in Second Passing Test");

        }


        public void addLogsInExtentFirstFailingTest()
        {
            test = extent.CreateTest("First Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in First Failing Test");

            test.Log(Status.Info, "Assertion  First Failing Test ");

            test.Log(Status.Info, "Website is opened in First Failing Test");

        }


        public void addLogsInExtentSecondFailingTest()
        {
            test = extent.CreateTest("Second Failing Test").Info("Test Started");

            test.Log(Status.Info, "Url is entered in Second Failing Test");

            test.Log(Status.Info, "Assertion  Second Failing Test ");

            test.Log(Status.Info, "Website is opened in Second Failing Test");

        }














    }
}

