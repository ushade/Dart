using System;
using System.Text;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System.IO;
using OpenQA.Selenium;
using AventStack.ExtentReports.MarkupUtils;

namespace ATF.Common
{
    public class ExtentReport
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void BeforeSuite()
        {
            var path = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName;
            var dir = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Reports\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");


        }


        //[TearDown]
        //public void CloseBrowser(ITestResult result)
        //{
        //    if ((result.ResultState).Equals("failure"))
        //    {

        //        test.Log(Status.Fail, MarkupHelper.CreateLabel(result.Name + " Test case FAILED due to below issues:", ExtentColor.Red));
        //        test.Fail(result.Message);
        //    }
        //    else if ((result.ResultState).Equals("success"))
        //    {
        //        test.Log(Status.Pass, MarkupHelper.CreateLabel(result.Name + " Test Case PASSED", ExtentColor.Green));
        //    }
        //    else
        //    {
        //        test.Log(Status.Skip, MarkupHelper.CreateLabel(result.Name + " Test Case SKIPPED", ExtentColor.Orange));
        //        test.Skip(result.Message);
        //    }
        //}
        //[TearDown]
        //public void CloseBrowser()
        //{

        //    Status logstatus;
        //    string PathToFolder = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Screenshots\\";
        //    var status = TestContext.CurrentContext.Result.Outcome.Status;
        //    var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
        //            ? ""
        //            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

        //    var errorMessage = TestContext.CurrentContext.Result.Message;
        //    switch(status)
        //    {
        //        case TestStatus.Failed:
        //            logstatus = Status.Fail;
        //             break;
        //        case TestStatus.Inconclusive:
        //            logstatus = Status.Warning;
        //            break;
        //        case TestStatus.Skipped:
        //            logstatus = Status.Skip;
        //            break;
        //        default:
        //            logstatus = Status.Pass;
        //            //test.Log(logstatus, TestContext.CurrentContext.Test.Name);
        //            break;
        //    }
        //string s = BasicMethods.TakeScreenShot();
        //Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test case FAILED due to below issue:", ExtentColor.Red)).AddScreenCaptureFromPath(s);
        //Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test case FAILED due to below issues:", ExtentColor.Red)).AddScreenCaptureFromPath(s);
        //Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, stacktrace + errorMessage);
        //test.Log(Status.Fail, "Testcase Failed").AddScreenCaptureFromPath(s);
        //test.Fail("Failed details").AddScreenCaptureFromPath(s);

        //  }
        //  [TearDown]
        //public void CloseBrowser()
        //{
        //    //WriteLogFile.WriteLog("ConsoleLog", String.Format("{0} @ {1}", "Log is Created at", DateTime.Now));
        //    //Console.WriteLine("Log is Written Successfully !!!");
        //    //Console.ReadLine();
        //    //log.Info("Logged in successfully");

        //    //string PathToFolder = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Screenshots\\";
        //    //var status = TestContext.CurrentContext.Result.Outcome.Status;
        //    //var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
        //    //        ? ""
        //    //        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
        //    //var errorMessage = TestContext.CurrentContext.Result.Message;
        //    //Status logstatus;

        //    //switch (status)
        //    //{
        //    //    case TestStatus.Failed:
        //    //        logstatus = Status.Fail;
        //    //        test.Log(logstatus, stacktrace + errorMessage);
        //    //        string s = BasicMethods.TakeScreenShot();
        //    //        test.Fail("Failed details").AddScreenCaptureFromPath(s);
        //    //        break;
        //    //    case TestStatus.Inconclusive:
        //    //        logstatus = Status.Warning;
        //    //        break;
        //    //    case TestStatus.Skipped:
        //    //        logstatus = Status.Skip;
        //    //        break;
        //    //    default:
        //    //        logstatus = Status.Pass;
        //    //        test.Log(logstatus, "Test ended with " + logstatus);
        //    //        break;
        //    //}

        //}
        //public void CloseBrowser()
        //{
            //WriteLogFile.WriteLog("ConsoleLog", String.Format("{0} @ {1}", "Log is Created at", DateTime.Now));
            //    //Console.WriteLine("Log is Written Successfully !!!");
            //    //Console.ReadLine();
            //string PathToFolder = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Screenshots\\";

        [OneTimeTearDown]
        protected void AfterSuite()
        {

            extent.Flush();
            DriverUtils.driver.Quit();
        }

    }

}




