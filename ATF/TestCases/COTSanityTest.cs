using System;
using System.Text;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System.IO;
using OpenQA.Selenium;
using log4net.Config;

namespace ATF.TestCases
{
    class COTSanityTest
    {
        protected ExtentReports extent;
        protected ExtentTest test;
        static int ScreenCounter = 0;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [OneTimeSetUp]
            protected void Setup()
            {
                var path= Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName;
                var dir = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Reports\\";
                var fileName = this.GetType().ToString() + ".html";
                var htmlReporter = new ExtentHtmlReporter(dir + fileName);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                htmlReporter.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
            // allow automatic saving of media files relative to the report
            
        }

            [OneTimeTearDown]
            protected void TearDown()
            {
                extent.Flush();
            }

           [SetUp]
            public void BeforeTest()
            {
           
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }

            [TearDown]
            public void AfterTest()
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
                Status logstatus;
                var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build();
            
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

                test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            // adding screenshots to test
            //test.Fail("details").AddScreenCaptureFromPath(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Screenshots\\" + "screenshot.png");
            //test.Fail("details", mediaModel);
            //test.Fail("Details", MediaEntityBuilder.CreateScreenCaptureFromPath(Path.GetFullPath(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName) + "\\Screenshots\\screenshot.png").Build());
            TakesScreenshotWithDate(DriverUtils.driver, @"C:\UshaDevaraj\C#Project\ATF\ATF\Screenshots\", "File_Name_", System.Drawing.Imaging.ImageFormat.Jpeg);
            //Test.Fail("details", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            
            extent.Flush();
            }
        private void TakesScreenshotWithDate(IWebDriver BrowserInstance, string Path, string FileName, System.Drawing.Imaging.ImageFormat Format)
        {
            ScreenCounter++; //Updates the number of screenshots that we took during the execution

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            DirectoryInfo Validation = new DirectoryInfo(Path); //System IO object

            if (Validation.Exists == true) //Capture screen if the path is available
            {
                ((ITakesScreenshot)BrowserInstance).GetScreenshot().SaveAsFile(Path + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format);
            }
            else //Create the folder and then Capture the screen
            {
                Validation.Create();
                ((ITakesScreenshot)BrowserInstance).GetScreenshot().SaveAsFile(Path + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format);
            }
        }

        [Test]
       
        public void PassingTest()
        {
            XmlConfigurator.Configure();
            DriverUtils.opendriver(DriverUtils.Browser.IE);
            DriverUtils.driver.Navigate().GoToUrl("http://www.com");
            try
            {
                Assert.IsTrue(true);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }
        [Test]
        public void FailingTest()
        {
            XmlConfigurator.Configure();
            DriverUtils.opendriver(DriverUtils.Browser.IE);
            DriverUtils.driver.Navigate().GoToUrl("http://www.yahoo.com");

            try
            {
                Assert.IsTrue(false);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }
   }
 }