using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ATF.PageOperations;
using excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using OpenQA.Selenium;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace ATF.TestCases
{
    public class OrdersRegressionTest : ATF.Common.ExtentReport
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void LaunchBrowser()
        {

            String url = "http://cos-test.psr.rd.hpicorp.net/COSWeb/";
            Console.WriteLine("Opening url");
            DriverUtils.opendriver(DriverUtils.Browser.IE);
            DriverUtils.driver.Navigate().GoToUrl(url);
            DriverUtils.driver.Manage().Window.Maximize();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            // startInfo.FileName = "cmd.exe";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C chromedriver.exe --disable-extensions --verbose --log-path=chromedriver.log";
            process.StartInfo = startInfo;
            process.Start();
        }
        [TearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("closing browser");
            //Checks whether Driver is not null and then kills the WebDriver using Quit
            if (DriverUtils.driver != null)
            {
                extent.Flush();
                DriverUtils.driver.Quit();
            }
        }
        [Test]
        public void CreateOrderWithoutMSDSTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Functionality to test new chemcial order with an empty MSDS");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var NOrderPage = new NewOrderPage();
            BasicMethods.CheckImage(LoginPage.HPLogo);
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            NOrderPage.OrderTab.ClickBtn();
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            NOrderPage.InputCostCenter(NOrderPage.OrderPageCostCenter, "TA1011");
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "TA-M111");
            NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, "TA-S111");
            NOrderPage.AddBtn.ClickBtn();
            NOrderPage.CASInput(NOrderPage.CAS, "TA-CAS111");
            NOrderPage.SupplierPhoneInput(NOrderPage.SupplierPhone, "1001000121");
            NOrderPage.SupplierURLInput(NOrderPage.SupplierURL, "https://google.co.in");
            NOrderPage.MaterialURLInput(NOrderPage.MaterialURL, "https://google.co.in");
            NOrderPage.ProductNumberInput(NOrderPage.ProductNumber, "test1");
            NOrderPage.ContactNameInput(NOrderPage.ContactName, "AUser1");
            NOrderPage.ContactEmailInput(NOrderPage.ContactEmail, "Auser1@yopmail.com");
            NOrderPage.ContactPhoneInput(NOrderPage.ContactPhone, "1234567890");
            NOrderPage.QuantityInput(NOrderPage.OrderPageQuantity, "5");
            NOrderPage.selectQtyUnit(NOrderPage.QuantityUnit, NOrderPage.DDLQtyUnit, 5);
            NOrderPage.CostInput(NOrderPage.OrderPageCost, "100");
            NOrderPage.SelectCostPerUnit(NOrderPage.CostPerUnit, NOrderPage.DDLCostUnit, 3);
            NOrderPage.InputDateNeeded(NOrderPage.DateNeeded,"2018/7/15");
            NOrderPage.SelectCopyTo("Farzaneh Barmaki");
            NOrderPage.SelectCopyTo("David Espinoza");
            NOrderPage.InputComments(NOrderPage.Comments, "WithoutMSDSTest");
            NOrderPage.SubmitOrderBtn();
        }
        [Test]
        public void CreateOrderWithNewMSDSTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Functionality to test new chemcial order with MSDS");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var NOrderPage = new NewOrderPage();
            BasicMethods.CheckImage(LoginPage.HPLogo);
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            NOrderPage.OrderTab.ClickBtn();
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            NOrderPage.InputCostCenter(NOrderPage.OrderPageCostCenter, "Cost2");
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "Acid");
            NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, "TASupplier");
            NOrderPage.InputMSDS(NOrderPage.MSDS, "C:\\Users\\devaraju\\Desktop\\pdf-sample.pdf");
            NOrderPage.AddBtn.ClickBtn();
            NOrderPage.CASInput(NOrderPage.CAS, "TA-CAS111");
            NOrderPage.SupplierPhoneInput(NOrderPage.SupplierPhone, "1001000121");
            NOrderPage.SupplierURLInput(NOrderPage.SupplierURL, "https://google.co.in");
            NOrderPage.MaterialURLInput(NOrderPage.MaterialURL, "https://google.co.in");
            NOrderPage.ProductNumberInput(NOrderPage.ProductNumber, "Product2");
            NOrderPage.ContactNameInput(NOrderPage.ContactName, "AUser2");
            NOrderPage.ContactEmailInput(NOrderPage.ContactEmail, "Auser2@yopmail.com");
            NOrderPage.ContactPhoneInput(NOrderPage.ContactPhone, "104789");
            NOrderPage.QuantityInput(NOrderPage.OrderPageQuantity, "10");
            NOrderPage.selectQtyUnit(NOrderPage.QuantityUnit, NOrderPage.DDLQtyUnit, 5);
            NOrderPage.CostInput(NOrderPage.OrderPageCost, "200");
            NOrderPage.SelectCostPerUnit(NOrderPage.CostPerUnit, NOrderPage.DDLCostUnit, 3);
            NOrderPage.InputDateNeeded(NOrderPage.DateNeeded, "2018/7/22");
            NOrderPage.SelectCopyTo("Farzaneh Barmaki");
            NOrderPage.SelectCopyTo("David Espinoza");
            NOrderPage.InputComments(NOrderPage.Comments, "WithMSDSTest");
            NOrderPage.SubmitOrderBtn();
        }
        [Test]
        public void CreateOrderForExistingRawMaterialTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Functionality to test new chemcial order with an empty MSDS");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var NOrderPage = new NewOrderPage();
            BasicMethods.CheckImage(LoginPage.HPLogo);
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            NOrderPage.OrderTab.ClickBtn();
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "Succinic Acid");
            BasicMethods.ClickBtn(NOrderPage.MaterialSearchBtn);
            Thread.Sleep(3000);
            BasicMethods.VerifyText(NOrderPage.FirstRowText, "Succinic acid");
            NOrderPage.FirstRowText.Click();
            Thread.Sleep(3000);
            Validations.validateTextInTextBox(NOrderPage.OrderPageSupplierName, "SIGMA-ALDRICH");
            Validations.validateTextInTextBox(NOrderPage.OrderPageMSDSUpload, "037925.pdf");
            BasicMethods.ClickBtn(NOrderPage.AddBtn);
            BasicMethods.VerifyText(NOrderPage.MaterialNameLabel, "Succinic acid");
            BasicMethods.VerifyText(NOrderPage.SupplierNameLabel, "SIGMA-ALDRICH");
            Validations.validateElementIsPresent(NOrderPage.MSDSPreviewLink);
            NOrderPage.CASInput(NOrderPage.CAS, "TA-CAS10");
            NOrderPage.SupplierPhoneInput(NOrderPage.SupplierPhone, "543456780");
            NOrderPage.SupplierURLInput(NOrderPage.SupplierURL, "https://google.co.in");
            NOrderPage.MaterialURLInput(NOrderPage.MaterialURL, "https://google.co.in");
            NOrderPage.ProductNumberInput(NOrderPage.ProductNumber, "Prod1");
            NOrderPage.ContactNameInput(NOrderPage.ContactName, "AutoUser5");
            NOrderPage.ContactEmailInput(NOrderPage.ContactEmail, "AutoUser5@yopmail.com");
            NOrderPage.ContactPhoneInput(NOrderPage.ContactPhone, "104789");
            NOrderPage.QuantityInput(NOrderPage.OrderPageQuantity, "5");
            NOrderPage.selectQtyUnit(NOrderPage.QuantityUnit, NOrderPage.DDLQtyUnit, 5);
            NOrderPage.CostInput(NOrderPage.OrderPageCost, "100");
            NOrderPage.SelectCostPerUnit(NOrderPage.CostPerUnit, NOrderPage.DDLCostUnit, 3);
            NOrderPage.InputDateNeeded(NOrderPage.DateNeeded, "2018/7/25");
            NOrderPage.SelectCopyTo("Farzaneh Barmaki");
            NOrderPage.SelectCopyTo("David Espinoza");
            NOrderPage.InputComments(NOrderPage.Comments, "Order Request for Existing Chemical");
            NOrderPage.SubmitOrderBtn();
        }
        [Test]
        public void CreateMultipleOrdersTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Functionality to test with multiple orders");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var NOrderPage = new NewOrderPage();
            //Declaring column names
            String MaterialName;
            String SupplierName;
            String MSDS;
            String CAS;
            String SupplierPhone;
            String SupplierURL;
            String MaterialURL;
            String ProductNumber;
            String ContactName;
            String ContactEmail;
            String ContactPhone;
            String Quantity;
            String QuantityUnit;
            String Cost;
            String CostUnit;
            String Date;
          
            BasicMethods.CheckImage(LoginPage.HPLogo);
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            NOrderPage.OrderTab.ClickBtn();
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            NOrderPage.InputCostCenter(NOrderPage.OrderPageCostCenter, "TestCenter");

            //To locate table.

            // Creates excel application
            excel.Application x1appln = new excel.Application();
            //Creates excel workbook object for specified file
            excel.Workbook wb = x1appln.Workbooks.Open(@"C:\\UshaDevaraj\\C#Project\\ATF\\ATF\\DataFile\\COTDataSheet.xlsx");
            //Creates excel work sheet object for sheet 1
            excel.Worksheet ws = wb.Sheets[3];
            //Creates excel work sheet object for sheet name
            //excel.Worksheet ws = wb.Sheets["DataSet"];
            //Gets used range of excel file. This will get currently how many rows occupied in sheet.
            excel.Range range = ws.UsedRange;
            int xlRowCnt = 1;
            // To get all rows values we have iterate through all rows one by one in for loop
            for (xlRowCnt = 2; xlRowCnt <= range.Rows.Count; xlRowCnt++)
            {

                MaterialName = Convert.ToString(range.Cells[xlRowCnt, 1].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 1].Value2);
                SupplierName = Convert.ToString(range.Cells[xlRowCnt, 2].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 2].Value2);
                MSDS = Convert.ToString(range.Cells[xlRowCnt, 3].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 3].Value2);
                CAS = Convert.ToString(range.Cells[xlRowCnt, 4].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 4].Value2);
                SupplierPhone = Convert.ToString(range.Cells[xlRowCnt, 5].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 5].Value2);
                SupplierURL = Convert.ToString(range.Cells[xlRowCnt, 6].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 6].Value2);
                MaterialURL = Convert.ToString(range.Cells[xlRowCnt, 7].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 7].Value2);
                ProductNumber = Convert.ToString(range.Cells[xlRowCnt, 8].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 8].Value2);
                ContactName = Convert.ToString(range.Cells[xlRowCnt, 9].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 9].Value2);
                ContactEmail = Convert.ToString(range.Cells[xlRowCnt, 10].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 10].Value2);
                ContactPhone = Convert.ToString(range.Cells[xlRowCnt, 11].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 11].Value2);
                Quantity = Convert.ToString(range.Cells[xlRowCnt, 12].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 12].Value2);
                QuantityUnit = Convert.ToString(range.Cells[xlRowCnt, 13].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 13].Value2);
                Cost = Convert.ToString(range.Cells[xlRowCnt, 14].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 14].Value2);
                CostUnit = Convert.ToString(range.Cells[xlRowCnt, 15].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 15].Value2);
                Date = Convert.ToString(range.Cells[xlRowCnt, 16].Value2) == null ? "" : Convert.ToString(range.Cells[xlRowCnt, 16].Value2);
                
                //Calls Orderpage methods
                NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, MaterialName);
                NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, SupplierName);
                NOrderPage.InputMSDS(NOrderPage.MSDS, MSDS);
                NOrderPage.AddBtn.ClickBtn();
                NOrderPage.InputCAS(xlRowCnt-1, CAS);
                NOrderPage.InputSupplierPhone(xlRowCnt - 1, SupplierPhone);
                NOrderPage.InputSupplierURL(xlRowCnt - 1, SupplierURL);
                NOrderPage.InputMaterialURL(xlRowCnt - 1, MaterialURL);
                NOrderPage.InputProductNumber(xlRowCnt - 1, ProductNumber);
                NOrderPage.InputContactName(xlRowCnt - 1, ContactName);
                NOrderPage.InputContactEmail(xlRowCnt - 1, ContactEmail);
                NOrderPage.InputContactPhone(xlRowCnt - 1, ContactPhone);
                NOrderPage.InputQuantity(xlRowCnt - 1, Quantity);
                NOrderPage.selectQtyUnit(xlRowCnt - 1, Convert.ToInt32(QuantityUnit));
                NOrderPage.InputCost(xlRowCnt - 1, Cost);
                NOrderPage.SelectCostPerUnit(xlRowCnt - 1, Convert.ToInt32(CostUnit));
                NOrderPage.selectDateNeeded(xlRowCnt - 1,Date);
            }
            NOrderPage.SelectCopyTo("Farzaneh Barmaki");
            NOrderPage.SelectCopyTo("David Espinoza");
            NOrderPage.InputComments(NOrderPage.Comments,"MultipleOrdersTest");
           // NOrderPage.SubmitOrderBtn();
            wb.Close();
            x1appln.Quit();
        }

        [Test]
        public void OrderPageUITest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Order Page UI test");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var NOrderPage = new NewOrderPage();
            BasicMethods.CheckImage(LoginPage.HPLogo);
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            NOrderPage.OrderTab.ClickBtn();
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            Validations.validateElementIsPresent(NOrderPage.MaterialSearchBtn);
            Validations.validateElementIsEnabled(NOrderPage.OrderPageMaterialName);
            Validations.validateElementIsEnabled(NOrderPage.OrderPageSupplierName);
            Validations.validateElementIsEnabled(NOrderPage.OrderPageMSDSUpload);
            Validations.validateElementIsEnabled(NOrderPage.AddBtn);
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "test");
            NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, "test");
            BasicMethods.ClickBtn(NOrderPage.AddBtn);
            Validations.validateElementNotPresent(NOrderPage.MSDSPreviewLink);
            Validations.validateElementIsEnabled(NOrderPage.Comments);
            Validations.validateElementIsEnabled(NOrderPage.OrderSubmitBtn);
        }
        [Test]
        public void OrderPageErrorValidationTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Order Page UI test");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var NOrderPage = new NewOrderPage();
            BasicMethods.CheckImage(LoginPage.HPLogo);
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            NOrderPage.OrderTab.ClickBtn();
            NOrderPage.VerifyRequester(NOrderPage.OrderPageRequester);
            NOrderPage.VerifyRequestedDate(NOrderPage.OrderPageRequestedDate);
            NOrderPage.InputCostCenter(NOrderPage.OrderPageCostCenter, "");
            BasicMethods.ClickBtn(NOrderPage.OrderSubmitBtn);
            BasicMethods.VerifyText(NOrderPage.txtCostCenterError, "Cost Center should not be empty.");
            NOrderPage.InputCostCenter(NOrderPage.OrderPageCostCenter, "IN20000830"); 
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "");
            NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, "");
            BasicMethods.ClickBtn(NOrderPage.AddBtn);
            BasicMethods.VerifyText(NOrderPage.txtMaterialError, "Material Name should not be empty.");
            BasicMethods.VerifyText(NOrderPage.txtSupplierError, "Supplier Name should not be empty.");
            BasicMethods.ClickBtn(NOrderPage.OrderSubmitBtn);
            BasicMethods.VerifyText(NOrderPage.TableNoRowError, "No Records added.");
            NOrderPage.InputMaterialName(NOrderPage.OrderPageMaterialName, "test");
            NOrderPage.InputSupplierName(NOrderPage.OrderPageSupplierName, "test");
            BasicMethods.ClickBtn(NOrderPage.AddBtn);
            BasicMethods.ClickBtn(NOrderPage.OrderSubmitBtn);
            BasicMethods.VerifyText(NOrderPage.TableError, "Some of the mandatory fields are empty.");
            NOrderPage.SelectCopyTo("Farzaneh Barmaki");
            NOrderPage.SelectCopyTo("Usha Devaraj");
            NOrderPage.SelectCopyTo("Navaneetha Krishnan");
            NOrderPage.SelectCopyTo("David Espinoza");
            BasicMethods.ClickBtn(NOrderPage.OrderSubmitBtn);
            BasicMethods.VerifyText(NOrderPage.approverError, "Copy To should not be empty.");
            NOrderPage.InputMSDS(NOrderPage.MSDS, "C:\\UshaDevaraj\\Documents\\COS\\COS\\COT-ReleaseNotes.docx");
            BasicMethods.VerifyText(NOrderPage.MSDSUploadError, "Please upload pdf only.");
            BasicMethods.ClickBtn(NOrderPage.InfoCloseBtn);



        }
    }
}
