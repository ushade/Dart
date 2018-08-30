using System;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace ATF.PageOperations
{
    public class HomePage
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomePage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }
        //Home Page Objects
        [FindsBy(How = How.XPath, Using = "//a[@href='/COSWeb/Home/Index']")]
        public IWebElement HomeTab { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='w3-xxxlarge'])[1]")]
        public IWebElement COTBanner1 { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='w3-xxxlarge'])[2]")]
        public IWebElement COTBanner2 { get; set; }
        [FindsBy(How = How.XPath, Using = "//img[@id='my_logo_image']")]
        public IWebElement HPBannerLogo { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='w3-justify'])[2]/h2[1]")]
        public IWebElement Last10RequestsHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Chemical Order Request')]")]
        public IWebElement COTLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Log Off')]")]
        public IWebElement LogOffBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//img[@id='my_logo_image']")]
        public IWebElement HomePageMyLogo { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]")]
        public IWebElement TableHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[2]")]
        public IWebElement FirstRow { get; set; }
        [FindsBy(How = How.TagName, Using = "a")]
        public static IList<IWebElement> LinkElements { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Home Page']")]
        public IWebElement HomeBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Dolphin']")]
        public IWebElement DolphinBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Sigma-Aldrich']")]
        public IWebElement SigmaAldrichBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Fisher Scientific']")]
        public IWebElement FisherScientificBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Class-Worldwide Classification Tool']")]
        public IWebElement ClassWWToolBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Fedex Tracking Tool']")]
        public IWebElement FedexBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Google Search']")]
        public IWebElement GoogleSearchBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'HP San Diego - Chemical Waste Collection and Conta')]")]
        public IWebElement ChemicalWasteCollectionRequestFormLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Hewlett Packard - San Diego - Ink, Chemical, Gas, ')]")]
        public IWebElement InkChemicalRequestFormLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Hewlett Packard - San Diego - Inventory Request Fo')]")]
        public IWebElement InventoryRequestFormLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Hewlett Packard - San Diego - Return to Stock or S')]")]
        public IWebElement ReturnToStockFormLink { get; set; }

        public void TestThirdPartyToolsLink(IWebElement element, string title)
        {
            string BaseWindow = DriverUtils.driver.CurrentWindowHandle;
            BasicMethods.ClickBtn(element);
            //switch to new window.
            DriverUtils.driver.SwitchTo().Window(DriverUtils.driver.WindowHandles.Last());
            Thread.Sleep(3000);
            DriverUtils.driver.Manage().Window.Maximize();
            Validations.validateTitle(title);
            DriverUtils.driver.Close();
            //if you want to switch back to your first window
            DriverUtils.driver.SwitchTo().Window(DriverUtils.driver.WindowHandles.First());
            Console.WriteLine("In home page now");
        }
        public void TestMainTabs(IWebElement element,string title)
        {
            BasicMethods.ClickBtn(element);
            Thread.Sleep(300);
            Validations.validateTitle(title);
            BasicMethods.ClickBtn(HomeBtn);
        }
      


        //        public void VerifyEmail()
        //{
        //    ReadOnlyCollection<IWebElement> links = DriverUtils.driver.FindElements(By.TagName("a"));
        //    foreach (IWebElement link in links)
        //    {
        //        String email = link.GetAttribute("href");
        //        Console.WriteLine("Email" + email);
        //      //  if (jscript.startsWith("mailto:"))

        //    }
        //DriverUtils.driver.FindElement(By.PartialLinkText("<a href"));
        //<a href = "mailto:farzaneh.barmaki@hp.com" > Farzaneh Barmaki</a>


        //            String linkText = "pee...@test.com";
        //            WebElement anchor = driver.findElement(By.linkText(linkText));
        //            String href = anchor.getAttribute("href");

        //            Now href will hold the link to the mailto: *BUT * you have multiple scenarios you need to deal with. I'd handle it with something like:

        //if (jscript.startsWith("mailto:"))
        //            {
        //                // handle a straight mailto: string
        //            }
        //            else if (jscript.startsWith("javascript:") {
        //                // handle a javascript which generates the mailto: string
        //            }
        //            else
        //            {
        //                // handle unknown href
        //                fail("Could not figure out how to process href: '" + href + "'");
        //            }
        // }
    }
}
