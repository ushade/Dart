using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ATF.PageOperations
{
    class OrdersPage
    {
        public OrdersPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }

        //OrderPage Objects
        [FindsBy(How = How.XPath, Using = "//a[@href='/COSWeb/Order/Order']")]
        public IWebElement OrderTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='lblRequester']")]
        public IWebElement OrderPageRequester { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtCostCenter']")]
        public IWebElement OrderPageCostCenter { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='dtRequestDate']")]
        public IWebElement OrderPageRequestedDate { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtMaterial']")]
        public IWebElement OrderPageMaterialName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierName']")]
        public IWebElement OrderPageSupplierName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@accept='.pdf']")]
        public IWebElement MSDS { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtCAS']")]
        public IWebElement CAS { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierPhone']")]
        public IWebElement SupplierPhone { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierURL']")]
        public IWebElement SupplierURL { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtMaterialURL']")]
        public IWebElement MaterialURL { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtProductNumber']")]
        public IWebElement ProductNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierContactName']")]
        public IWebElement ContactName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierContactEmail']")]
        public IWebElement ContactEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='txtSupplierContactPhone']")]
        public IWebElement ContactPhone { get; set; }
         [FindsBy(How = How.XPath, Using = "(//*[@class='k-widget k-numerictextbox txt'])[1]")]
        //[FindsBy(How = How.XPath, Using = "(//*[@class='k-formatted-value txt k-input'])[1]")]
        public IWebElement OrderPageQuantity { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-widget k-dropdown k-header'])[1]")]
        public IWebElement QuantityUnit { get; set; }
         [FindsBy(How = How.XPath, Using = "(//*[@class='k-widget k-numerictextbox txt'])[2]")]
       // [FindsBy(How = How.XPath, Using = "(//*[@class='k-formatted-value txt k-input'])[2]")]
        public IWebElement OrderPageCost { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-widget k-dropdown k-header'])[2]")]
        public IWebElement CostPerUnit { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@aria-controls='dtDateNeeded_dateview']")]
        public IWebElement DateNeeded { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='k-multiselect-wrap k-floatwrap']")]
        public IWebElement CopyTo { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@id='txtComments']")]
        public IWebElement Comments { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='submitOrderButton']")]
        public IWebElement OrderSubmitBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id ='ddlUnit_listbox']")]
        public IWebElement ddlUnitlistbox { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id ='ddlQuantityUnit_listbox']")]
        public IWebElement QtyDDList { get; set; }
        
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
        public void InputCAS(IWebElement CAS, String cas)
        {
            BasicMethods.EnterText(CAS, cas);
        }
        public void InputSupplierPhone(IWebElement SupplierPhone, String supplierphone)
        {
            BasicMethods.EnterText(SupplierPhone, supplierphone);
        }
        public void InputSupplierURL(IWebElement SupplierURL, String supplierurl)
        {
            BasicMethods.EnterText(SupplierURL, supplierurl);
        }
        public void InputMaterialURL(IWebElement MaterialURL, String materialurl)
        {
            BasicMethods.EnterText(MaterialURL, materialurl);
        }
        public void InputProductNumber(IWebElement ProductNumber, String prodnumber)
        {
            BasicMethods.EnterText(ProductNumber, prodnumber);
        }
        public void InputContactName(IWebElement ContactName, String contactname)
        {
            if (!string.IsNullOrEmpty(ContactPhone.Text))
            {
                BasicMethods.EnterText(ContactName, contactname);
                DriverUtils.driver.FindElement(By.XPath("//*[@id='txtSupplierContactName-list']//li[contains(text(),'Usha D')]")).Click();
            }
            else
            {
                BasicMethods.EnterText(ContactName, contactname);
            }
         }
        public void InputContactEmail(IWebElement ContactEmail, String contactemail)
        {
            if (!string.IsNullOrEmpty(ContactEmail.Text))
            {
                return;
            }
            else
            {
                BasicMethods.EnterText(ContactEmail, contactemail);
            }
       }
        public void InputContactPhone(IWebElement ContactPhone, String contactphone)
        {
            if (!string.IsNullOrEmpty(ContactPhone.Text))
            {
                return;
            }
            else
            {
                BasicMethods.EnterText(ContactPhone, contactphone);
            }
        }

        public void InputQuantity(IWebElement OrderPageQuantity,string Qty)
        {
            Actions act = new Actions(DriverUtils.driver);
            //Scroll unitl the element is within the display
            act.MoveToElement(OrderPageQuantity).Click(OrderPageQuantity).SendKeys(Qty).Build().Perform();
        }
        public void selectQtyUnit(IWebElement QuantityUnit)
        {
            //Wait until an element is visible / clickable
            var wait = new WebDriverWait(DriverUtils.driver, TimeSpan.FromMinutes(1));
            QuantityUnit.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id ='ddlQuantityUnit_listbox']")));
            DriverUtils.driver.FindElement(By.XPath("html/body/div[8]/div/div[2]/ul/li[5]")).Click();
         }
        public void InputCost(IWebElement OrderPageCost,string cost)
        {
            Actions act1 = new Actions(DriverUtils.driver);
            act1.MoveToElement(OrderPageCost).Click(OrderPageCost).SendKeys(cost).Build().Perform();
        }
        public void SelectCostPerUnit(IWebElement CostPerUnit)
        {
            var wait1 = new WebDriverWait(DriverUtils.driver, TimeSpan.FromMinutes(1));
            CostPerUnit.Click();
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id ='ddlUnit_listbox']")));
            DriverUtils.driver.FindElement(By.XPath("html/body/div[7]/div/div[2]/ul/li[5]")).Click();
        }
        public void SelectDateNeeded()
        {
            DateNeeded.Click();
            DriverUtils.driver.FindElement(By.XPath("//*[@data-value='2018/4/29']")).Click();
        }
        public void SelectCopyTo()
        {
            CopyTo.Click();
            DriverUtils.driver.FindElement(By.XPath("//*[@id='approver_listbox']//li[contains(text(),'Navaneetha Krishnan')]")).Click();
            CopyTo.Click();
            DriverUtils.driver.FindElement(By.XPath("//*[@id='approver_listbox']//li[contains(text(),'Pallavi RV')]")).Click();
        }
        public void InputComments(IWebElement Comments,String comments)
        {
            BasicMethods.EnterText(Comments,comments);
        }
        public void SubmitOrderBtn()
        {
            OrderSubmitBtn.Submit();
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