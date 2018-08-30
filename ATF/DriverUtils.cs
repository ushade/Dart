using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ATF
{
    class DriverUtils
    {
        //Start WebDriver
        public static IWebDriver opendriver(Browser browser)
        {
            Console.WriteLine("Opening seleniumdriver");
            driver = null;
            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    FirefoxDriver webDriver = new FirefoxDriver(service);
                    break;
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case Browser.IE:
                    InternetExplorerDriverService ieservice = InternetExplorerDriverService.CreateDefaultService();
                    ieservice.SuppressInitialDiagnosticInformation = true;
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driver = new InternetExplorerDriver(ieservice, options);
                    driver.Manage().Window.Maximize();
                    break;
            }
            if(driver!= null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
            }
            return driver;

        }
        public enum Browser
        {
            Chrome,
            Firefox,
            IE
        }
        public static IWebDriver driver { get; set; }

        public static Browser return_browser()
        {
            Browser browser = Browser.Chrome;
            return browser;

        }

        public static void LaunchBrowser(String url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

        }
        public static void CloseBrowser()
        {
            driver.Quit();

        }

        public static void Refresh()
        {
            driver.Navigate().Refresh();
        }
        public static void Back()
        {
            driver.Navigate().Back();
            
        }
        public static void Forward()
        {
            driver.Navigate().Forward();
            
        }


        ////Function to implicitly wait an element for specified amount of time in milliseconds
        // public static void wait_time(int timeout=10)
        //{
        //    for (var i =0; i< timeout; i++)
        //    {
        //        Thread.Sleep(1000);
        //    }
        //}
        ////Function to explicitly wait an element on the page
        //public static IWebElement find_element(By by)
        //{
        //    int TimeoutInSeconds = 5000;
        //    if (TimeoutInSeconds > 0)
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeoutInSeconds));
        //        return wait.Until(d => d.FindElement(by));
        //    }
        //    return driver.FindElement(by);
        //}



    }
}
