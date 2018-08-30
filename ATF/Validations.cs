using System;
using OpenQA.Selenium;
using NUnit.Framework;
using ATF.Common;
using AventStack.ExtentReports;
using System.Diagnostics;
using AventStack.ExtentReports.MarkupUtils;

namespace ATF
{
    
    public static class Validations 
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static void validateScreenByUrl(String screenUrl)
        {
           
            String currentURL = DriverUtils.driver.Url;
            
            try
            {
                if (String.Equals(screenUrl, currentURL))
                {
                  Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "ValidateScreenByURLTest- Passed");
                 }
                else
                {
                  
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "ValidateScreenByURLTest - Failed");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Mismatch URL screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }

        }


        public static void validateTitle(String title)
        {
            
            String currentitle = DriverUtils.driver.Title;
            try
            {
                if (String.Equals(title, currentitle))
                {
                    
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given title \t" + title + "\t matches with the webpage");
                }
                else
                {
                   
                    Common.ExtentReport.test.Log(Status.Fail, "The given title" + " \t " + currentitle + "\t" + " doesn't match with the webpage");
                    Console.WriteLine("Observed Title : " + currentitle);
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Mismatch Title screenshot" + " \t " , ExtentColor.Red)).AddScreenCaptureFromPath(s);

                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
        }
        public static void validateElementIsPresent(this IWebElement element)
        {
           
            try
            {
                if (element.Displayed)
                {
                   
                    Console.WriteLine("The given element" + " \t " + " \t " + element.Text + " \t " + "is present in the webpage");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given element" + " \t " + element.Text +" \t " + "exist in the webpage");
                }
                else
                {
                  
                    Console.WriteLine("The given element" + " \t " + element.Text + " \t " + "doesnt exist in the webpage");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given element" + " \t " + element.Text + " \t " + "doesnt exist in the webpage");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
            
        }
        public static void validateElementNotPresent(this IWebElement element)
        {

            try
            {
                if (!element.Displayed)
                {

                    Console.WriteLine("The given element" + " \t " + " \t " + element.Text + " \t " + "doesnt exist in the webpage");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given element" + " \t " + element.Text + " \t " + "doesnt exist in the webpage");
                }
                else
                {

                    Console.WriteLine("The given element" + " \t " + element.Text + " \t " + "is present in the webpage");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given element" + " \t " + element.Text + " \t " + "is present in the webpage");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }

        }
        public static void validateElementIsEnabled(this IWebElement element)
        {

            bool status = element.Enabled;
            try
            {
                if (status)
                {
                    Console.WriteLine("The given element" + " \t " + element.Text + " \t " + "is enabled by default");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given element" + " \t " + element.Text + " \t " + "is enabled");
                }
                else
                {
                    Console.WriteLine("The given element" + " \t " + element.Text + " \t " + "is disabled");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given element" + " \t " + element.Text + " \t " + "is disabled");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
        }
        public static void validateElementIsDisabled(this IWebElement element)
        {

            bool status = element.Enabled;
            try
            {
                if (!status)
                {
                    Console.WriteLine("The given element" + " \t " + element.Text + " \t " + "is disabled by default");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given element" + " \t " + element.Text + " \t " + "is disabled");
                }
                else
                {
                    Console.WriteLine("The given element" + " \t " + element.Text + " \t " + "is enabled");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given element" + " \t " + element.Text + " \t " + "is enabled");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
        }
        public static void validateTextInElement(this IWebElement element, String text)
        {
           
            String findElement = element.Text;
            try
            {
                if(String.Equals(findElement,text))
                {
                    
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given text" + findElement + "exists");
                }
                else
                {
                   
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given text" + findElement + "does not exist");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }


            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }

        }
        public static void validateTextInTextBox(this IWebElement element, String expectedvalue)
        {

            String observedvalue = element.GetAttribute("value").ToString();
            try
            {
                if (String.Equals(observedvalue, expectedvalue))
                {

                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The " + " \t " + observedvalue + " \t " + "matches with the  expected string" + " \t " + expectedvalue);
                }
                else
                {

                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The " + " \t " + observedvalue + " \t " + "does not with the expected string" + " \t " + expectedvalue);
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Screenshot", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                }
            }


            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }

        }
    }
   }