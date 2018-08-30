using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.PageOperations;

namespace ATF.TestCases
{
    public class ManageOrdersRegressionTest : ATF.Common.ExtentReport
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void LaunchBrowser()
        {
            String url = "http://cos-test.psr.rd.hpicorp.net/COSWeb/";
            Console.WriteLine("Opening url");
            DriverUtils.opendriver(DriverUtils.Browser.IE);
            DriverUtils.LaunchBrowser(url);
        }
        [TearDown]
        public void CloseBrowser()
        {
            //WriteLogFile.WriteLog("ConsoleLog", String.Format("{0} @ {1}", "Log is Created at", DateTime.Now));
            //    //Console.WriteLine("Log is Written Successfully !!!");
            //    //Console.ReadLine();
            //string PathToFolder = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Screenshots\\";
            extent.Flush();
            DriverUtils.driver.Quit();
        }

        [Test]
        public void ManageOrdersUITest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Verify UI elements in manage users page");
            var LoginPage = new LoginPage();
            var ManageOrders = new ManageOrdersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            BasicMethods.ClickBtn(ManageOrders.ManageOrdersTab);
            Validations.validateTitle("Manage Orders - Chemical Ordering Tool");
            Validations.validateScreenByUrl("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageOrder/ManageOrder");
            Validations.validateElementIsEnabled(ManageOrders.HideShowBtn);
            Validations.validateElementIsPresent(ManageOrders.ExportToExcelBtn);
            Validations.validateElementIsPresent(ManageOrders.ManageOrderStatusBtn);
            BasicMethods.VerifyText(ManageOrders.ManageOrderTableHeader, "Actions Order No Requester Cost Center Requested Date Material Name Supplier Name Cost Quantity Is New Msds Status");
            BasicMethods.VerifyText(ManageOrders.PendingForApprovalStatus, "Status: Pending For Approval");
            BasicMethods.VerifyText(ManageOrders.WaitingforMSDSStatus, "Status: Waiting for MSDS");
            BasicMethods.VerifyText(ManageOrders.RejectedStatus, "Status: Rejected");
            BasicMethods.VerifyText(ManageOrders.OrderedStatus, "Status: Ordered");
            BasicMethods.VerifyText(ManageOrders.ClosedStatus, "Status: Closed");
            BasicMethods.VerifyText(ManageOrders.ApprovedStatus, "Status: Approved");
            BasicMethods.ClickBtn(ManageOrders.WithFilterExpandButton);
            BasicMethods.VerifyPartialText(ManageOrders.ManageOrderTableRow, "Approved");
            BasicMethods.ClickBtn(ManageOrders.HideShowBtn);
            ManageOrders.Testcheckbox();
        }

        [Test]
        public void Testcase2()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Hide/Show functionality");
            var LoginPage = new LoginPage();
            var ManageOrders = new ManageOrdersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            BasicMethods.ClickBtn(ManageOrders.ManageOrdersTab);
            BasicMethods.ClickBtn(ManageOrders.HideShowBtn);
            ManageOrders.Testcheckbox();
            //ManageOrders.HideShowFuncTest();
           // ManageOrders.HideShowFuncTest();
            Console.WriteLine("Expected text" + "\t" + ManageOrders.Table.Text);
           
        }


    }
}
