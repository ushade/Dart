using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AventStack.ExtentReports.MarkupUtils;

namespace ATF.PageOperations
{
   public class LoginPage
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }

        //LoginPage PageObjects
        
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement UserName { get; set; }
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement LoginInBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='logo']")]
        public IWebElement HPLogo { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='welcomeheader']")]
        public IWebElement WelcomeHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//ul[@class='uk-navbar-nav uk-navbar-text']")]
        public IWebElement Welcometitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='alert alert-info']")]
        public IWebElement WelcomeBanner { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm']/form/h5 ")]
        public IWebElement LoginFormTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//html/body/div[2]/h5")]
        public IWebElement ContactusLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//h2[contains(.,'Last 10 Requests')]")]
        public IWebElement Last10RequestsTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='validation-summary-errors']")]
        public IWebElement BlankErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[2]/ul[1]/li[1]")]
        public IWebElement BlankEmailErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[2]/ul[1]/li[2]")]
        public IWebElement BlankPasswordErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='field-validation-error'])[1]")]
        public IWebElement EmailErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='field-validation-error'])[2]")]
        public IWebElement PasswordErrorMsg { get; set; }

        public static void Login(IWebElement usn, String usnvalue, IWebElement pwd, String pwdvalue, IWebElement btn, IWebElement expectedtext)
        {
            usn.EnterText(usnvalue);
            pwd.EnterText(pwdvalue);
            btn.Submit();
            Thread.Sleep(3000);
            bool text = expectedtext.Displayed;
            if (text)
            {
                Console.WriteLine("Logged in successfully");
                log.Info("Logged in successfully");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Logged in successfully");
            }
            else
            {
                Console.WriteLine("Login failed");
                log.Info("Login failed");
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Login Failed", ExtentColor.Red)).AddScreenCaptureFromPath(s);
            }
        }
    }
}