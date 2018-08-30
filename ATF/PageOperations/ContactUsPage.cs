using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
//using SeleniumExtras.PageObjects;

namespace ATF.PageOperations
{
    public class ContactUsPage
    {
        public ContactUsPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }
        //Contactus PageObjects

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Contact')]")]
        public IWebElement ContactTab { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/ul/li[1]/h5")]
        public IWebElement COTContactPerson { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/ul/li[2]/h5")]
        public IWebElement COTSupport { get; set; }
    }
}
