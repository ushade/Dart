using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using static ATF.DriverUtils;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Model;
using iTextSharp.text;

namespace ATF
{
    
    public static class BasicMethods 
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //static int ScreenCounter = 0;
        public static void EnterText(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);

        }
        //Click method
        public static void ClickBtn(this IWebElement element)
        {
            element.Click();
        }
        //Clear method
        public static void ClearText(this IWebElement element)
        {
            element.Clear();
        }
        //Drop down ul method
        public static void DropDownFunction(IWebElement dropdownelement, IWebElement ddlistbox, int ddloption)
        {
            dropdownelement.Click();
            ddlistbox.FindElement(By.XPath(".//li"));
            ddlistbox.FindElements(By.XPath(".//li")).ElementAt(ddloption).Click();
           

        }


        //public void DropDownFunc(IWebElement Dropdownelement, IList<IWebElement> ddlistbox, String ddloption)
        //{
        //    Dropdownelement.Click();
        //    IList<IWebElement> ec = ddlistbox;
        //    // IList<IWebElement> ec = DriverUtils.driver.FindElements(By.XPath("//*[@id='userRole_listbox']/li"));
        //    for (int k = 0; k < ec.Count; k++)
        //    {
        //        if (ec[k].Text == ddloption)
        //        {
        //            ec[k].Click();
        //            //String result = ec[k].Text;
        //            //Console.WriteLine("Selected option" + "\t" + ddloption);
        //            Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, ddloption);
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid option" + ec[k].Text);
        //            string s = BasicMethods.TakeScreenShot();
        //            Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Invalid option", ExtentColor.Red)).AddScreenCaptureFromPath(s);
        //        }

        //    }

        //}
        //    public static bool SelectElementContainsItemText(SelectElement selElem, string itemText)
        //{
        //    bool found = false;

        //    for (int i = 0; i < selElem.Options.Count; i++)
        //    {
        //        var blah = selElem.Options[i].Text;
        //        if (selElem.Options[i].Text.Equals(itemText))
        //        {
        //            found = true;
        //            break;
        //        }
        //    }

        //    return found;
        //}
        //    //Drop down select method
        //    public static void SelectElement(SelectElement selElem, string value)
        //    {

        //        //Get the size of the select element
        //        IList<IWebElement> size = selElem.Options;
        //        //Get the count of avaialabe options
        //        int count = size.Count;

        //        for (int i = 0; i < count; i++)
        //        {
        //            // Storing the value of the option	
        //            String sValue = selElem.Options.ElementAt(i).Text;
        //            // Printing the stored value
        //            //Console.WriteLine("Value of the Select item is : " + sValue);

        //            // Putting a check on each option that if any of the option is equal to 'Africa" then select it 
        //            if (sValue.Equals(value))
        //            {
        //                Console.WriteLine("Value of the Select item is : " + sValue);
        //                selElem.SelectByIndex(i);
        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine("option not found: " + sValue);
        //                break;
        //            }
        //        }
        //    }

        public static void SelectDropdown(this IWebElement element, string value)
        {
            element.Click();
            new SelectElement(element).SelectByValue(value);

          // return found;
        }
           
            //  element.Click();
            //new SelectElement(element).SelectByValue(value);
            //  Console.WriteLine("Selected option \t" + value);
            //Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Selected option" +"\t" + value);
     
        //or
        //new SelectElement(element).SelectByIndex(value); //value is integer
        //or
        // new SelectElement(element).SelectByText(value);

        //IWebElement sTag = driver.FindElement(By.Id("sel123"));
        //OpenQA.Selenium.Support.UI.SelectElement selectTag = new OpenQA.Selenium.Support.UI.SelectElement(sTag);
        //selectTag.SelectByValue("admin");
        ////Or
        //selectTag.SelectByText("Admin");
        ////Or
        //selectTag.SelectByIndex(3);
        //To verify how many options are available in select tag 
        //var availableOptions = selectTag.Options;
        //foreach (IWebElement item in availableOptions)
        //{
        //    Console.WriteLine(item.Text);
        //}

        //public static void SelectDDL(this IWebElement dropDownList, String selectedText)
        //{

        //    {
        //        ListItem selectedlistitem = dropDownList.items.findbytext(selectedText);

        //        if (selectedlistitem != null)
        //        {
        //            selectedlistitem.Selected = true;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    WebExtensions.SetSelectedText(MyDropDownList, "MyValue");
        //}

        //function to find elment
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            else
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(drv => drv.FindElement(by));
            }

        }

        //WebDriver.FindElement(By.id(“Element”),WaitTime)

        //alertBox
        public static void AlertBox(this IWebElement image, IAlert alert)
        {
            alert = DriverUtils.driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Accept();
            try
            {
                if (image.Displayed)
                {
                    Console.WriteLine("The alert was successfuly accepted and I can see the image!");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The alert was successfuly accepted and I can see the image!");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Something went wrong!!");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "Something went wrong!!");
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(" Test case FAILED due to below issue:", ExtentColor.Red)).AddScreenCaptureFromPath(s);

            }
            Thread.Sleep(3000);
        }
        //Fucntion to check if checkbox is checked by default
        public static void CheckBox(this IWebElement element)
        {
            bool isChecked = bool.TryParse(element.GetAttribute("checked"), out isChecked);
            if (isChecked)
            {
                Console.WriteLine("This checkbox is already checked!");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "This checkbox is already checked!");
            }
            else
            {
                Console.WriteLine("Huh, someone left the checkbox unchecked, lets check it!");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "Huh, someone left the checkbox unchecked, lets check it!");
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(" Test case FAILED due to below issue:", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                //element.Click();
            }
        }
        //Fucntion to check the radio button
        public static void RadioButton(this IWebElement element)
        {
            if (element.GetAttribute("checked") == "true")
            {
                Console.WriteLine("radio button is checked!");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "radio button is checked!");
            }
            else
            {
                Console.WriteLine("This is one of the unchecked radio buttons!");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "This is one of the unchecked radio buttons!");
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Observed Image", ExtentColor.Red)).AddScreenCaptureFromPath(s);
            }
        }
        //Image Verification function
        public static void CheckImage(this IWebElement element)
        {
            IWebElement ImageFile = element;
            Boolean ImagePresent = (Boolean)((IJavaScriptExecutor)DriverUtils.driver).ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", ImageFile);
            if (ImagePresent)
            {
                Console.WriteLine("Image displayed.");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Image exist");

            }
            else
            {
                Console.WriteLine("Image not displayed.");
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Image is missing", ExtentColor.Red)).AddScreenCaptureFromPath(s);
            }
        }
        //PartialVerificationText Function

        public static void VerifyPartialText(this IWebElement element, String text)
        {
            try
            {
                if (!string.IsNullOrEmpty(element.Text) && (!string.IsNullOrWhiteSpace(element.Text) && element.Text.Contains(text)))
                {
                    Console.WriteLine("Matched Text:" + "\n" + element.Text);
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given string" + " \t " + element.Text + " \t " + "matches with the expected text" + " \t " + text);
                }
                else
                {
                    Console.WriteLine("Mismatched Text: \n" + element.Text);
                    //Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "Mismatched text" + "\t" + element.Text);
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Mismatched Value" + "\t" + element.Text, ExtentColor.Red)).AddScreenCaptureFromPath(s);
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given string does not exist" + " \t " + element.Text + " \t " + "in the expected string" + " \t " + text);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
     }

        public static void DefaultValue(this IWebElement element)
        {
            try
            {
                if (string.IsNullOrEmpty(element.Text) && (string.IsNullOrWhiteSpace(element.Text)))
                {
                    Console.WriteLine("Default value is empty");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Default value is empty" + "\t" + element.Text);
                }
                else
                {
                    Console.WriteLine("Not an empty field by default: \t" + element.Text);
                    //Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "Mismatched text" + "\t" + element.Text);
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Mismatched Text" + "\t" + element.Text, ExtentColor.Red)).AddScreenCaptureFromPath(s);

                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
        }

        //VerifyText Function
        public static void VerifyText(this IWebElement element, String text)
        {
            try
            {
                if (!string.IsNullOrEmpty(element.Text) && (!string.IsNullOrWhiteSpace(element.Text) && element.Text == text))
                {
                    Console.WriteLine("Matched Text:" + " \t " + element.Text);
                    Log.Info("Text matched");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given string" + " \t " + element.Text + " \t " + "matches with the expected text" + " \t " + text);

                }
                else
                {
                    Console.WriteLine("Expected Text" + text);
                    Console.WriteLine("Observed Text" + element.Text);
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Mismatched Text \t" + " \t " + element.Text, ExtentColor.Red)).AddScreenCaptureFromPath(s);
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given string does not exist" + " \t " + element.Text + " \t " + "in the expected string" + " \t " + text);
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
   }
      
        public static string GetAttributeValue(this IWebElement element)
        {
            String elementtext = null;
            elementtext = element.GetAttribute("value");
            return elementtext;
            //Console.WriteLine("The given element \t" + element + "Attribute value is\t" + elementtext);
        }


        public static string GetTextFromDDL(this IWebElement element)
        {

            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;

        }
        public static string GetText(this IWebElement element)
        {
            String elementtext = null;
            elementtext = element.Text;
            return elementtext;
            //Console.WriteLine("The given element \t" + element + "Attribute value is\t" + elementtext);
        }
        public static void GetSize(this IWebElement element)
        {
            Size dimension = element.Size;
            Console.WriteLine("Height :" + dimension.Height + "Width :" + dimension.Width);
        }
        public static void GetLocation(this IWebElement element)
        {
            Point point = element.Location;
            Console.WriteLine("X Cordinate :" + point.X + "Y cordinate : " + point.Y);
        }
        public static void checkWebsite()
        {
            ReadOnlyCollection<IWebElement> links = DriverUtils.driver.FindElements(By.TagName("a"));
            foreach (IWebElement link in links)
            {
                String url = link.GetAttribute("href");
                try
                {
                    WebClient wc = new WebClient();
                    string htmlsource = wc.DownloadString(url);
                    Console.WriteLine("The given url\t" + " \t " + url  +" \t " + "is working");
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "The given url\t" + " \t " + url + " \t " +  "is working");
                }
                catch (Exception)
                {
                    Console.WriteLine("The given url\t" + " \t " + url + " \t " + "is not working");
                   // Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "The given url\t" + url + "\t\t" + "is not working");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("The given url\t" + " \t " + url + " \t " +  "is not working", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                  
                }
            }
        }
        //Function to switch frame
        public static void SwitchFrameByIndex(int value)
        {
            //Getting number of iFrames in webPage

            IList<IWebElement> iframe = DriverUtils.driver.FindElements(By.TagName("iframe"));

            int size = iframe.Count;
            try
            {
                if(size!=0)
                {
                    driver.SwitchTo().Frame(value);
                    Console.WriteLine("Switched to Frame index value is \t" + " \t " + value);
                    Log.Info("Frame value" + value);
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Switched to frame");
                }
                else
                {
                    //Switch back to default window
                    Console.WriteLine("No frames");
                    log.Info("No frames");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("No frames", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                    log.Info("Switching to main frame");
                    driver.SwitchTo().DefaultContent();
                }
           }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }
       }
        public static void SwitchFrameByName(string value)
        {
            //Getting number of iFrames in webPage
            //Here value is "iframe1"
            IList<IWebElement> iframe = DriverUtils.driver.FindElements(By.TagName("iframe"));

            int size = iframe.Count;
            try
            {
                if (size != 0)
                {
                    driver.SwitchTo().Frame(value);
                    Console.WriteLine("Switched to Frame Name \t" + value);
                    Log.Info("Frame value" + value);
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Switched to frame");
                }
                else
                {
                    //Switch back to default window
                    Console.WriteLine("No frames");
                    log.Info("No frames");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("No frames", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                    log.Info("Switching to main frame");
                    driver.SwitchTo().DefaultContent();
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }

        }
        public static void SwitchFrameByID(string value)
        {
            //Getting number of iFrames in webPage
            //Here value is "Id of iframe" for eg : <frame id='test'......</frame>
            //driver.SwitchTo().Frame(driver.FindElement(By.Xpath("//frame[@src='/somesrc' and not(@id='unloadFrame')]")));

            IList<IWebElement> iframe = DriverUtils.driver.FindElements(By.TagName("iframe"));

            int size = iframe.Count;
            try
            {
                if (size != 0)
                {
                    driver.SwitchTo().Frame(value);
                    Console.WriteLine("Switched to Frame ID \t" + value);
                    Log.Info("Frame value" + value);
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Switched to frame");
                }
                else
                {
                    //Switch back to default window
                    Console.WriteLine("No frames");
                    log.Info("No frames");
                    string s = BasicMethods.TakeScreenShot();
                    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("No frames", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                    log.Info("Switching to main frame");
                    driver.SwitchTo().DefaultContent();
                }
            }
            catch (AssertionException ex)
            {
                string s = ex.GetBaseException().Message;
                log.Info(s);
            }

        }
        
        public static void HoverAndClick(IWebElement elementToClick)
        {
            Actions action = new Actions(DriverUtils.driver);
            action.MoveToElement(elementToClick).Click(elementToClick).Build().Perform();
        }
        //Function to check syntax of email with regular expression
        //public static bool isEmail(string inputEmail)
        //{
        //    inputEmail = NulltoString(inputEmail);
        //    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        //          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        //          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //    Regex re = new Regex(strRegex);
        //    if (re.IsMatch(inputEmail))
        //        return (true);
        //    else
        //        return (false);
        //}

        public static void Hover(this IWebElement element)
        {
            Actions action = new Actions(DriverUtils.driver);
            action.MoveToElement(element).Perform();
        }


        //public static Boolean SetSelectedText(this DropDownList dropDownList, String selectedText)
        //{
        //    ListItem selectedListItem = dropDownList.Items.FindByText(selectedText);

        //    if (selectedListItem != null)
        //    {
        //        selectedListItem.Selected = true;
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        //WebExtensions.SetSelectedText(MyDropDownList, "MyValue");

        //public static void Login(this IWebElement usn, String usnvalue, IWebElement pwd, String pwdvalue, IWebElement btn)
        //{

        //    usn.EnterText(usnvalue);
        //    pwd.EnterText(pwdvalue);
        //    btn.ClickBtn();
        //}
        //public static void LogOff(this IWebElement btn)
        //{
        //    btn.ClickBtn();
        //}
        //Verify broken links

        //Function
        //Uploading a file called "Products.xls"

        //public void FileUpload()
        //{
        //    //The first step gets the base directory and the file
        //    string File = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Products.xls";
        //    Browser.FindElement(By.Id("File"), LongLongWaitTime).SendKeys(File);

        //}


        //     public void MouseHover_SubMenuClick(string PrimaryMenu, string SubMenu)
        //{
        //    //Doing a MouseHover  
        //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        //    var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PrimaryMenu)));
        //    Actions action = new Actions(Driver);
        //    action.MoveToElement(element).Perform();
        //    //Clicking the SubMenu on MouseHover   
        //    var menuelement = Browser.FindElement(By.XPath(SubMenu), LongLongWaitTime);
        //    menuelement.Click();
        //}
        //        First I do a mousehover on the element say PrimaryMenu “Science”
        //Then Click on the submenu “Energy” that is displayed
        //Menu XPath is the XPath of menu for which you have to perform a hover operation
        //public void JustMouseHover(String MenuXPath)
        //{

        //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        //    var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MenuXPath)));
        //    Actions action = new Actions(Driver);
        //    action.MoveToElement(element).Perform();
        //    //Waiting for the menu to be displayed    
        //    System.Threading.Thread.Sleep(4000);
        //}

        //Taking Screenshot in C#
        // PathToFolder is the location where we need to save the screenshot
        // FileName is another string where PathToFolder is appended with timestamp
        static int count = 0;
        public static string TakeScreenShot()
        {
            count++;
            string PathToFolder = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Screenshots\\";
            string fileName = PathToFolder + "Error" + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg";
            DirectoryInfo Validation = new DirectoryInfo(PathToFolder);
            if (Validation.Exists == true) //Capture screen if the path is available
            {
                Screenshot cp = ((ITakesScreenshot)driver).GetScreenshot();
                cp.SaveAsFile(fileName, OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
            else
            {
                Validation.Create();
                Screenshot cp = ((ITakesScreenshot)driver).GetScreenshot();
                cp.SaveAsFile(fileName, OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
                return (fileName);
            
            //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            //Screenshot screenCapture = screenshotDriver.GetScreenshot();
            //screenCapture.SaveAsFile(PathToFolder + "\\" + "wrongUserNameAndPassword.png", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);

        }
        //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(PathToFolder + ScreenCounter.ToString() + Runname);
        
    }
}         // var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build();