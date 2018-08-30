using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;


namespace ATF.PageOperations
{
    class NewOrderPage
    {
        public NewOrderPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }

        //OrderPage Objects
        [FindsBy(How = How.XPath, Using = "//a[@href='/COSWeb/Order/OrderRequest']")]
        public IWebElement OrderTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='lblRequester']")]
        public IWebElement OrderPageRequester { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtCostCenter']")]
        public IWebElement OrderPageCostCenter { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='dtRequestDate']")]
        public IWebElement OrderPageRequestedDate { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtMaterial']")]
        public IWebElement OrderPageMaterialName { get; set; }
        [FindsBy(How = How.XPath, Using = "//i[@onclick='OpenSearchPopup();']")]
        public IWebElement MaterialSearchBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='txtMSDS']")]
        public IWebElement OrderPageMSDSUpload { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lblMSDS_')]")]
        public IWebElement MSDSPreviewLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='search_list_tbl']")]
        public IWebElement RMSearchTable { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr[@role='row']")]
        public IWebElement TableHeader { get; set; }
        //[FindsBy(How = How.XPath, Using = "//table/tbody/tr[@class='bottom_border odd'][1]")]
        [FindsBy(How = How.XPath, Using = "//*[@class='sorting_1']")]
        public IWebElement FirstRowText { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@aria-controls='search_list_tbl']")]
        public IWebElement SearchText { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierName']")]
        public IWebElement OrderPageSupplierName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@accept='.pdf']")]
        public IWebElement MSDS { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='AddOrderButton']")]
        public IWebElement AddBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tblOrderList']")]
        public IWebElement RMOrderListTable { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr[@class='bottom_border']")]
        public IWebElement RMOrderListTableHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[@class='bottom_border']")]
        public IWebElement RMOrderListTableRow { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@id,'lblMaterialName_')]")]
        public IWebElement MaterialNameLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@id,'lblSupplierName_')]")]
        public IWebElement SupplierNameLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtCAS_')]")]
        public IWebElement CAS { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSupplierPhone_')]")]
        public IWebElement SupplierPhone { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSupplierURL_')]")]
        public IWebElement SupplierURL { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtMaterialURL_')]")]
        public IWebElement MaterialURL { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtProductNumber_')]")]
        public IWebElement ProductNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSupplierContactName_')]")]
        public IWebElement ContactName { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[starts-with(@id,'txtSupplierContactName_') and contains(@id,'_listbox')]")]
        public IWebElement ContactDDList { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSupplierContactEmail_')]")]
        public IWebElement ContactEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSupplierContactPhone_')]")]
        public IWebElement ContactPhone { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='removeOrderListRow']")]
        public IWebElement RMDeleteBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@aria-controls,'dateview')]")]
        public IWebElement DateNeeded { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='k-multiselect-wrap k-floatwrap']")]
        public IWebElement CopyTo { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@id='txtComments']")]
        public IWebElement Comments { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='submitOrderButton']")]
        public IWebElement OrderSubmitBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-formatted-value txt orderRequest k-input'])[1]")]
        public IWebElement OrderPageQuantity { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-formatted-value txt orderRequest k-input'])[2]")]
        public IWebElement OrderPageCost { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-widget k-dropdown k-header orderRequest'])[1]")]
        public IWebElement QuantityUnit { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[starts-with(@id,'ddlQuantityUnit_') and contains(@id,'_listbox')]")]
        public IWebElement DDLQtyUnit { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-widget k-dropdown k-header orderRequest'])[2]")]
        public IWebElement CostPerUnit { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[starts-with(@id,'ddlUnit_') and contains(@id,'_listbox')]")]
        public IWebElement DDLCostUnit { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='approver-list']")]
        public IWebElement DDLApprover { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='txtMaterialError']")]
        public IWebElement txtMaterialError { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='txtSupplierNameError']")]
        public IWebElement txtSupplierError { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='txtCostCenterError']")]
        public IWebElement txtCostCenterError { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='txtMSDSError']")]
        public IWebElement txtMSDSError { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='approverError']")]
        public IWebElement approverError { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='Ordermessage']")]
        public IWebElement Ordermessage { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='trTableNoRowError']")]
        public IWebElement TableNoRowError { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='trTableError']")]
        public IWebElement TableError { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='UploadDialog']")]
        public IWebElement MSDSUploadError { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-icon k-i-close'])[2]")]
        public IWebElement InfoCloseBtn { get; set; }
        
        
        public void InputCostCenter(IWebElement OrderPageCostCenter, String costcenter)
        {
            BasicMethods.EnterText(OrderPageCostCenter, costcenter);
        }
        public void InputMaterialName(IWebElement OrderPageMaterialName, String materialname)
        {
            BasicMethods.EnterText(OrderPageMaterialName, materialname);
        }
        public void InputSupplierName(IWebElement OrderPageSupplierName, String suppliername)
        {
            BasicMethods.EnterText(OrderPageSupplierName, suppliername);
        }
        public void InputMSDS(IWebElement MSDS, String msds)
        {
            BasicMethods.EnterText(MSDS, msds);
        }
        public void CASInput(IWebElement CAS, String cas)
        {
            BasicMethods.EnterText(CAS, cas);
        }
        public void SupplierPhoneInput(IWebElement SupplierPhone, String supplierphone)
        {
            BasicMethods.EnterText(SupplierPhone, supplierphone);
        }
        public void SupplierURLInput(IWebElement SupplierURL, String supplierurl)
        {
            BasicMethods.EnterText(SupplierURL, supplierurl);
        }
        public void MaterialURLInput(IWebElement MaterialURL, String materialurl)
        {
            BasicMethods.EnterText(MaterialURL, materialurl);
        }
        public void ProductNumberInput(IWebElement ProductNumber, String productnumber)
        {
            BasicMethods.EnterText(ProductNumber, productnumber);
        }
        public void ContactNameInput(IWebElement ContactName, String contactname)
        {
            BasicMethods.EnterText(ContactName, contactname);
           // ContactDDList.FindElement(By.XPath(".//li[contains(text(),'Usha D')]")).Click();
        }
        public void ContactEmailInput(IWebElement ContactEmail, String contactemail)
        {
            BasicMethods.EnterText(ContactEmail, contactemail);
        }
        public void ContactPhoneInput(IWebElement ContactPhone, String contactphone)
        {
            BasicMethods.EnterText(ContactPhone, contactphone);
        }
        public void QuantityInput(IWebElement OrderPageQuantity, string Qty)
        {
            //Actions act = new Actions(DriverUtils.driver);
            //Scroll unitl the element is within the display
            // act.MoveToElement(OrderPageQuantity).Click(OrderPageQuantity).SendKeys(Qty).Build().Perform();
            OrderPageQuantity.Clear();
            ((IJavaScriptExecutor)DriverUtils.driver).ExecuteScript("arguments[0].scrollIntoView(true);", OrderPageQuantity);
            OrderPageQuantity.SendKeys(Qty);
        }
         public void selectQtyUnit(IWebElement QuantityUnit, IWebElement DDLQtyUnit, int unit)
        {
            QuantityUnit.Click();
            DDLQtyUnit.FindElement(By.XPath(".//li"));
            DDLQtyUnit.FindElements(By.XPath(".//li")).ElementAt(unit).Click();
        }
        public void CostInput(IWebElement OrderPageCost, String cost)
        {
            Actions act1 = new Actions(DriverUtils.driver);
            act1.MoveToElement(OrderPageCost).Click(OrderPageCost).SendKeys(cost).Build().Perform();
        }
        public void SelectCostPerUnit(IWebElement CostPerUnit, IWebElement DDLCostUnit, int costunit)
        {
            CostPerUnit.Click();
            DDLCostUnit.FindElement(By.XPath(".//li"));
            DDLCostUnit.FindElements(By.XPath(".//li")).ElementAt(costunit).Click();
        }
        public void InputDateNeeded(IWebElement DateNeeded, String date)
        {
            DateNeeded.Click();
            DriverUtils.driver.FindElement(By.XPath("//*[@data-value='" + date + "']")).Click();
        }
        public void InputCAS(int tableRowId, string cas)
        {
            //IWebElement baseTable = DriverUtils.driver.FindElement(By.XPath("//*[@id='tblOrderList']"));
            //IList<IWebElement> rows = baseTable.FindElements(By.XPath("//*[@id='tblOrderList']/tbody/tr/td"));
            //IList<IWebElement> columns = baseTable.FindElements(By.XPath("//*[@id='tblOrderList']/thead/tr/th"));
            //for (int i = 1; i <= CAS.Count; i++)
            //{
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtCAS_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtCAS_')])[" + tableRowId + "]")).SendKeys(cas);
            //}
        }
        public void InputSupplierPhone(int tableRowId, String supplierphone)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierPhone_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierPhone_')])[" + tableRowId + "]")).SendKeys(supplierphone);
        }
        public void InputSupplierURL(int tableRowId, String supplierurl)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierURL_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierURL_')])[" + tableRowId + "]")).SendKeys(supplierurl);
        }
        public void InputMaterialURL(int tableRowId, String materialurl)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtMaterialURL_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtMaterialURL_')])[" + tableRowId + "]")).SendKeys(materialurl);
        }
        public void InputProductNumber(int tableRowId, String prodnumber)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtProductNumber_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtProductNumber_')])[" + tableRowId + "]")).SendKeys(prodnumber);
        }
        public void InputContactName(int tableRowId, string contactname)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierContactName_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierContactName_')])[" + tableRowId + "]")).SendKeys(contactname);
            
        }

        public void InputContactEmail(int tableRowId, String contactemail)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierContactEmail_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierContactEmail_')])[" + tableRowId + "]")).SendKeys(contactemail);
        }
        public void InputContactPhone(int tableRowId, String contactphone)
        {
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierContactPhone_')])[" + tableRowId + "]")).Clear();
            DriverUtils.driver.FindElement(By.XPath("(//input[contains(@id,'txtSupplierContactPhone_')])[" + tableRowId + "]")).SendKeys(contactphone);
        }

        public void InputQuantity(int tableRowId, string Qty)
        {
            
            if (tableRowId % 2 != 0)
            {
               // Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + tableRowId + "]")).Clear();
                ((IJavaScriptExecutor)DriverUtils.driver).ExecuteScript("arguments[0].scrollIntoView(true);", DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + tableRowId + "]")));
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + tableRowId + "]")).SendKeys(Qty);
            }
            else
            {
                //Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 1) + "]")).Clear();
                ((IJavaScriptExecutor)DriverUtils.driver).ExecuteScript("arguments[0].scrollIntoView(true);", DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 1) + "]")));
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 1) + "]")).SendKeys(Qty);
            }
        }
       
        public void selectQtyUnit(int tableRowId, int value)
        {

            if (tableRowId % 2 != 0)
            {
                // Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-widget k-dropdown k-header orderRequest'])[" + tableRowId + "]")).Click();
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlQuantityUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElement(By.XPath(".//li"));
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlQuantityUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElements(By.XPath(".//li")).ElementAt(value).Click();
                
            }
            else
            {
                //Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-widget k-dropdown k-header orderRequest'])[" + (tableRowId + 1) + "]")).Click();
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlQuantityUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElement(By.XPath(".//li"));
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlQuantityUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElements(By.XPath(".//li")).ElementAt(value).Click();
            }
        }
        public void InputCost(int tableRowId, string cost)
        {
            
            if (tableRowId % 2 != 0)
            {
                // Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 1) + "]")).Clear();
                ((IJavaScriptExecutor)DriverUtils.driver).ExecuteScript("arguments[0].scrollIntoView(true);", DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 1) + "]")));
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 1) + "]")).SendKeys(cost);
            }
            else
            {
                //Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 2) + "]")).Clear();
                ((IJavaScriptExecutor)DriverUtils.driver).ExecuteScript("arguments[0].scrollIntoView(true);", DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 2) + "]")));
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-formatted-value txt orderRequest k-input'])[" + (tableRowId + 2) + "]")).SendKeys(cost);
            }
        }
        
        public void SelectCostPerUnit(int tableRowId, int value)
        {
           
            if (tableRowId % 2 != 0)
            {
                // Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-widget k-dropdown k-header orderRequest'])[" + (tableRowId+1) + "]")).Click();
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElement(By.XPath(".//li"));
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElements(By.XPath(".//li")).ElementAt(value).Click();

            }
            else
            {
                //Console.WriteLine(tableRowId.ToString());
                DriverUtils.driver.FindElement(By.XPath("(//*[@class='k-widget k-dropdown k-header orderRequest'])[" + (tableRowId + 2) + "]")).Click();
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElement(By.XPath(".//li"));
                DriverUtils.driver.FindElement(By.XPath("(//*[starts-with(@id,'ddlUnit_') and contains(@id,'_listbox')])[" + tableRowId + "]")).FindElements(By.XPath(".//li")).ElementAt(value).Click();
            }
        }
         public void selectDateNeeded(int tableRowId,string date)
        {
            DriverUtils.driver.FindElement(By.XPath("(//span[contains(@aria-controls,'dateview')])[" + tableRowId + "]")).Click();
            DriverUtils.driver.FindElement(By.XPath("(//*[@data-value='"+date+"'])["+ tableRowId + "]")).Click();
        }
        
        public void SelectCopyTo(string membername)
        {
            CopyTo.Click();
            DDLApprover.FindElement(By.XPath("//li[contains(text(),'"+ membername +"')]")).Click();
            //CopyTo.Click();
            //DDLApprover.FindElement(By.XPath("//li[contains(text(),'Farzaneh Barmaki')]")).Click();
            // CopyTo.Click();
            // DDLApprover.FindElement(By.XPath("//li[contains(text(),'Navaneetha Krishnan')]")).Click();

        }
        public void InputComments(IWebElement Comments, String comments)
        {
            BasicMethods.EnterText(Comments, comments);
        }
        public void SubmitOrderBtn()
        {
            OrderSubmitBtn.Click();
        }
        public void VerifyRequester(IWebElement OrderPageRequester)
        {
            String ExpectedText = "Usha Devaraj";
            String ObservedText = OrderPageRequester.Text;
            Console.WriteLine("Requester Name" + ObservedText);
            if (ExpectedText == ObservedText)
            {
                Console.WriteLine("Requester Matches with the given value");
            }
            else
            {
                Console.WriteLine("Failed to match");
            }
        }
        public void VerifyRequestedDate(IWebElement OrderPageRequestedDate)
        {
            String ExpectedText = DateTime.UtcNow.ToString("yyyy-MM-dd");
            String ObservedText = OrderPageRequestedDate.GetAttribute("value");
            Console.WriteLine("Today's date" + ExpectedText);
            Console.WriteLine("Requested Date" + ObservedText);
            if (ExpectedText == ObservedText)
            {
                Console.WriteLine("Requested Date Matches with the given value");
            }
            else
            {
                Console.WriteLine("Failed to match");
            }

        }
    }
}