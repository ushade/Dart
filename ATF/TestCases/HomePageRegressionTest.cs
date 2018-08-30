using ATF.PageOperations;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ATF.TestCases 
{
    public class HomePageRegressionTest : ATF.Common.ExtentReport
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

        public void ContactPageRegressionTest()
        {
            test = extent.CreateTest("ContactPageRegressionTest","Test includes verification of Contact Person and COT support details and validates the URL and Title");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var ContactPage = new ContactUsPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
             log.Info("Logged in Successfully");
            BasicMethods.ClickBtn(ContactPage.ContactTab);
            log.Info("In Contact Page - Test Passed");
          Validations.validateScreenByUrl("http://cos-test.psr.rd.hpicorp.net/COSWeb/Home/Contact");
          Validations.validateTitle("Contact - Chemical Ordering Tool");
          BasicMethods.VerifyText(ContactPage.COTContactPerson, "For questions regarding COS process or permissions, please contact - Farzaneh Barmaki(farzaneh.barmaki@hp.com)");
          BasicMethods.VerifyText(ContactPage.COTSupport, "To report COS database technical issues, please contact - COT Support (COS_Support@hp.com)");
          BasicMethods.ClickBtn(HomePage.LogOffBtn);
        }
        [Test]
        public void AboutPageUITest()
        {
            test = extent.CreateTest("AboutPageRegressionTest", "Test includes verification of UI elements in About Page");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var AboutPage = new AboutPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            BasicMethods.ClickBtn(AboutPage.AboutTab);
            log.Info("In About Page Screen");
            BasicMethods.ClickBtn(AboutPage.ReleaseNotesTab);
            AboutPage.VerifyReleaseNotes();
            log.Info("clicked ReleaseNotes Tab");
            BasicMethods.ClickBtn(AboutPage.UserManualTab);
            //AboutPage.VerifyUserManual();
            log.Info("Clicked UserManual");
            BasicMethods.ClickBtn(HomePage.LogOffBtn);

        }
        [Test]
        public void HomepageUITest()
        {
            test = extent.CreateTest("HomepageUITest", "Test includes verification of UI elements in Home Page");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var ContactPage = new ContactUsPage();
            var AboutPage = new AboutPage();
            var NOrderPage = new NewOrderPage();
            var ManageUser = new ManageUsersPage();
            var ManageOrders = new ManageOrdersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            BasicMethods.ClickBtn(HomePage.HomeTab);
            log.Info("In Home Page Screen");
            //  BasicMethods.GetLocation(HomePage.COTLink);
            // BasicMethods.GetSize(HomePage.COTLink);
            Validations.validateTitle("Home - Chemical Ordering Tool");
            BasicMethods.CheckImage(HomePage.HomePageMyLogo);
            BasicMethods.checkWebsite();
            BasicMethods.VerifyText(HomePage.COTBanner1, "Welcome To The");
            BasicMethods.VerifyText(HomePage.COTBanner2, "Chemical Ordering Tool");
            BasicMethods.VerifyText(HomePage.Last10RequestsHeader, "Last 10 Requests");
            HomePage.TestThirdPartyToolsLink(HomePage.DolphinBtn, "Comply Plus");
            HomePage.TestThirdPartyToolsLink(HomePage.SigmaAldrichBtn, "MilliporeSigma | United States");
            HomePage.TestThirdPartyToolsLink(HomePage.FedexBtn, "Tracking | FedEx Canada");
            HomePage.TestThirdPartyToolsLink(HomePage.FisherScientificBtn, "Fisher Scientific: Lab Equipment and Supplies");
            HomePage.TestThirdPartyToolsLink(HomePage.GoogleSearchBtn, "Google");
            HomePage.TestThirdPartyToolsLink(HomePage.ClassWWToolBtn, "WW-Class - Classification Online Request Form");
            HomePage.TestMainTabs(NOrderPage.OrderTab, "Order Request - Chemical Ordering Tool");
            HomePage.TestMainTabs(ManageOrders.ManageOrdersTab, "Manage Orders - Chemical Ordering Tool");
            ManageUser.SelectManageUsersTab();
            BasicMethods.ClickBtn(HomePage.HomeBtn);
            HomePage.TestMainTabs(HomePage.HomeTab, "Home - Chemical Ordering Tool");
            HomePage.TestMainTabs(AboutPage.AboutTab, "About - Chemical Ordering Tool");
            HomePage.TestMainTabs(ContactPage.ContactTab, "Contact - Chemical Ordering Tool");
            HomePage.TestThirdPartyToolsLink(HomePage.ChemicalWasteCollectionRequestFormLink, "HP San Diego - Chemical Waste Collection and Container Request Form - Formstack");
            HomePage.TestThirdPartyToolsLink(HomePage.InkChemicalRequestFormLink, "HP San Diego - Ink Pour, Chemical, Gas, Nitrogen Request Form - Formstack");
            HomePage.TestThirdPartyToolsLink(HomePage.ReturnToStockFormLink, "HP San Diego - Return to Stock or Scrap Form - Formstack");
            HomePage.TestThirdPartyToolsLink(HomePage.InventoryRequestFormLink, "HP San Diego - Inventory Request Form - Formstack");
        }
        [Test]
        public void CreateOrderUsingLinkTest()
        {
            test = extent.CreateTest("CreateOrderUsingLinkTest", "Test includes ordering chemical using chemical order request link in home page");
            var NOrderPage = new NewOrderPage();
            var HomePage = new HomePage();
            var LoginPage = new LoginPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            BasicMethods.ClickBtn(HomePage.COTLink);
            Thread.Sleep(3000);
            NOrderPage.InputCostCenter(NOrderPage.OrderPageCostCenter, "10");
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "Material-Name2");
            NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, "Supplier-Name2");
            NOrderPage.InputMSDS(NOrderPage.MSDS, "C:\\Users\\devaraju\\Desktop\\pdf-sample.pdf");
            Thread.Sleep(5000);
            NOrderPage.AddBtn.ClickBtn();
            NOrderPage.CASInput(NOrderPage.CAS, "123-23-2345");
            NOrderPage.SupplierPhoneInput(NOrderPage.SupplierPhone, "121");
            NOrderPage.SupplierURLInput(NOrderPage.SupplierURL, "https://google.co.in");
            NOrderPage.MaterialURLInput(NOrderPage.MaterialURL, "https://google.co.in");
            NOrderPage.ProductNumberInput(NOrderPage.ProductNumber, "Product012");
            NOrderPage.ContactNameInput(NOrderPage.ContactName, "AutoUser4");
            NOrderPage.ContactEmailInput(NOrderPage.ContactEmail, "AutoUser4@yopmail.com");
            NOrderPage.ContactPhoneInput(NOrderPage.ContactPhone, "103");
            NOrderPage.QuantityInput(NOrderPage.OrderPageQuantity,"20");
            NOrderPage.selectQtyUnit(NOrderPage.QuantityUnit, NOrderPage.DDLQtyUnit, 5);
            NOrderPage.CostInput(NOrderPage.OrderPageCost, "200");
            NOrderPage.SelectCostPerUnit(NOrderPage.CostPerUnit, NOrderPage.DDLCostUnit, 5);
            NOrderPage.InputDateNeeded(NOrderPage.DateNeeded, "2018/6/30");
            NOrderPage.SelectCopyTo("Farzaneh Barmaki");
            NOrderPage.SelectCopyTo("David Espinoza");
            NOrderPage.InputComments(NOrderPage.Comments, "OrderLinkTestinHomePage");
            NOrderPage.SubmitOrderBtn();
            BasicMethods.ClickBtn(HomePage.HomeTab);
            BasicMethods.VerifyText(HomePage.TableHeader,"Request Number Material Name Requested Date Quantity Date Needed");
            BasicMethods.VerifyPartialText(HomePage.FirstRow, "Material-Name2");
         }

    }
}
