//using System;
//using NUnit.Framework;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium;
//using System.Text;
//using ATF.PageOperations;
//using RelevantCodes.ExtentReports;
//using System.IO;

//namespace ATF.TestCases
//{
//    public class SanityTest
//    {
//        //Instance of extents reports

//        public static ExtentReports extent;

//        public static ExtentTest test;

//        private static readonly log4net.ILog log =
//      log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        [SetUp]
//        public void startReport()
//        {
//            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
//            Console.WriteLine("path" + path);
//            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
//            Console.WriteLine("actualPath" + actualPath);
//            string projectpath = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName;
//            Console.WriteLine("Project Path: " + projectpath);
//            //Append the html report file to current project path
//            string reportpath = projectpath + "\\Reports\\TestRunReport.html";
//            Console.WriteLine("Report Path:" + reportpath);
//            //Boolean value for replacing existing report -True - replace existing report,false - create new report
//            extent = new ExtentReports(reportpath, true, DisplayOrder.NewestFirst);

//            //Add QA system info to html report
//            extent.AddSystemInfo("Host Name", "Usha")
//                .AddSystemInfo("Environment", "Test")
//                .AddSystemInfo("Username", "Usha D");

//            //Adding config.xml file
//            //            extent.LoadConfig("C:\\UshaDevaraj\\C#Project\\ATF\\ATF\\extent-config.xml"); //Get the config.xml file from http://extentreports.com
//            extent.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
//            String url = "http://cos-test.psr.rd.hpicorp.net/COSWeb/";
//            Console.WriteLine("Opening url");
//            Log.Info("Application Launched!!!");
//            DriverUtils.opendriver(DriverUtils.Browser.IE);
//            DriverUtils.driver.Navigate().GoToUrl(url);
//            DriverUtils.driver.Manage().Window.Maximize();
//        }
//    [TearDown]

//        public void CloseBrowser()
//        {
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
//            var errorMessage = TestContext.CurrentContext.Result.Message;
//            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
//            {
               
//                test.Log(LogStatus.Fail, stackTrace + errorMessage);
               
//            }
//            extent.EndTest(test);
//        }

//        [OneTimeTearDown]
//        public void EndReport()
//        {
//            //End Report
//            DriverUtils.driver.Quit();
//            extent.Flush();
//            extent.Close();
//        }
//        [Test]
       
//        public void DemoPass()
//        {
//            var LoginPage = new LoginPage();
//            var ManageUsers = new ManageUsersPage();
//            var HomePage = new HomePage();
//            test = extent.StartTest("Test Login Page with valid credentials");
//            LoginPage.InvalidCredentialsTest(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July12018", LoginPage.LoginInBtn);
//            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "The Email field is not a valid e-mail address.");
//            test.Log(LogStatus.Fail, "text Mismatch");
//            LoginPage.ValidCredentialsTest(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
//            test.Log(LogStatus.Info, "Logged in successfully");
//        }
      
//      }
//    }