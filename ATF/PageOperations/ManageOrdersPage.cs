using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.PageOperations
{
    public class ManageOrdersPage
    {
        public ManageOrdersPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }
        //ManageOrders PageObjects
        [FindsBy(How = How.XPath, Using = "//a[@href='/COSWeb/ManageOrder/ManageOrder']")]
        public IWebElement ManageOrdersTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='ColumnVisibilityButton']")]
        public IWebElement HideShowBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@class='k-button k-button-icontext k-grid-excel']")]
        public IWebElement ExportToExcelBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='k-grouping-header']")]
        public IWebElement GroupingHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='RequesterName']")]
        public IWebElement ManageOrderRequester { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='Id']")]
        public IWebElement ManageOrderOrderNo { get; set; }
        [FindsBy(How = How.XPath, Using = " //*[@data-field='CostCenter']")]
        public IWebElement ManageOrderCostCenter { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='RequestDateForGrid']")]
        public IWebElement ManageOrderRequestedDate { get; set; }
        [FindsBy(How = How.XPath, Using = " //*[@data-field='MaterialName']")]
        public IWebElement ManageOrderMaterialName { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='k-header']")]
        public IWebElement Actions { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='SupplierName']")]
        public IWebElement ManageOrderSupplierName { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='Cost']")]
        public IWebElement ManageOrderCost { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='Quantity']")]
        public IWebElement ManageOrderQuantity { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='IsNewMsds']")]
        public IWebElement IsNewMsds { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-field='Status']")]
        public IWebElement ManageOrderStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@class='k-group-indicator'])[1]")]
        public IWebElement ManageOrderStatusBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[2]/div[2]/div/a[2]")]
        public IWebElement GroupingCloseBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr/th/a[2]")]
        public IWebElement ManageOrderTableHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]")]
        public IWebElement StatusRow { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[2]")]
        public IWebElement ManageOrderTableRow { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr/th[4]/a[1]")]
        public IWebElement OrderNoWithoutGroupFilterBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr/th[5]/a[1]")]
        public IWebElement OrderNoWithGroupFilterBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td/p/a")]
        public IWebElement WithFilterExpandButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[2]/td[3]/a[3]")]
        public IWebElement WithoutFilterExpandButton { get; set; }
        [FindsBy(How = How.XPath, Using = " //table/tbody/tr[2]/td/a")]
        public IWebElement WithFilterExpandTableRowButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[3]/td[3]/div/div/ul/li[1]")]
        public IWebElement StatusDetailsTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[3]/td[3]/div/div/ul/li[2]")]
        public IWebElement EditDetailsTab { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@role='grid'])[2]")]
        public IWebElement StatusTableHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@role='grid'])[3]")]
        public IWebElement StatusTableRow { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@role='grid'])[4]")]
        public IWebElement EditTableHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@role='grid'])[5]")]
        public IWebElement EditTableRow { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[165]/td/p")]
        public IWebElement WaitingforMSDSStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[146]/td/p")]
        public IWebElement RejectedStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[101]/td/p")]
        public IWebElement PendingForApprovalStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[96]/td/p")]
        public IWebElement OrderedStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[87]/td/p")]
        public IWebElement ClosedStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td/p")]
        public IWebElement ApprovedStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div[1]/div/a")]
        public IWebElement HideCloseBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr")]
        public IWebElement Table { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@checked='']")]
        public IList<IWebElement> HideColumnsOptions { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[starts-with(@id,'txtSupplierContactName_') and contains(@id,'_listbox')]")]
        //div[@id='checkboxes']//div[i]//label[1]
        //public IWebElement ContactDDList { get; set; }

        public void Testcheckbox()
        {
            // Find the checkbox or radio button element by Name
            // IList<IWebElement> CheckboxOptions = DriverUtils.driver.FindElements(By.Id("checkboxes"));
            // This will tell you the number of checkboxes are present
            IList<IWebElement> CheckboxOptions = DriverUtils.driver.FindElements(By.CssSelector("input[type='checkbox']"));
            //IList<IWebElement> CheckboxOptions = DriverUtils.driver.FindElements(By.XPath("//div[@id='checkboxes']/div"));
            int iSize = CheckboxOptions.Count;
           
           
            // Start the loop from first checkbox to last checkboxe
            for (int i = 0; i < iSize; i++)
             {
                if (CheckboxOptions.ElementAt(i).Selected)
                {
                    Console.WriteLine("This option is checked selected by default" + "\t" + CheckboxOptions.ElementAt(i).GetAttribute("checked"));
                    Console.WriteLine("This option is label selected by default" + "\t" + CheckboxOptions.ElementAt(i).GetAttribute("label"));
                    Console.WriteLine("This option is value selected by default" + "\t" + CheckboxOptions.ElementAt(i).GetAttribute("value"));
                    Console.WriteLine("This option is text selected by default" + "\t" + CheckboxOptions.ElementAt(i).Text);
                    break;
                }
                else
                {
                    Console.WriteLine("This options is not selected by default" + "\t" + CheckboxOptions.ElementAt(i).Text);
                }

                //// This will check that if the bValue is True means if the first radio button is selected
                //if (bValue == true)
                //{
                //    //Console.WriteLine("Total number of options selected by default"+"\t" + CheckboxOptions.ElementAt(i).GetAttribute("checked"));
                    
                    
                //}
                //    // This will select Second radio button, if the first radio button is selected by default
                        
                //else
                //{
                //    // If the first radio button is not selected by default, the first will be selected
                //   // Console.WriteLine("Following options are not selected by default" + "\t" + CheckboxOptions.ElementAt(i).GetAttribute("checked"));
                //    Console.WriteLine("Following options are not selected by default" + "\t" + CheckboxOptions.ElementAt(i).Text);
                //}
                // Store the checkbox name to the string variable, using 'Value' attribute
                // String Value = CheckboxOptions.ElementAt(i).GetAttribute("value");
                //// Select the checkbox it the value of the checkbox is same what you are looking for
                //if (Value.Equals("Automation Tester"))
                //{
                //    CheckboxOptions.ElementAt(i).Click();
                //    // This will take the execution out of for loop
                //    break;
                //}
                //    Console.WriteLine("Number of Checkbox options selected by default" + "\t" + CheckboxOptions.ElementAt(i).Text);
                //    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "This checkbox is already checked!" + CheckboxOptions.ElementAt(i).Text);
                //else
                //{
                //    Console.WriteLine("Following options are not selected by default" + "\t" + CheckboxOptions.ElementAt(i).Text);
                //    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, "Huh, someone left the checkbox unchecked, lets check it!");
                //    string s = BasicMethods.TakeScreenShot();
                //    Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(" Test case FAILED due to below issue:", ExtentColor.Red)).AddScreenCaptureFromPath(s);
                //}

            }
        }


        public void HideShowFuncTest()
        {
            // Find the checkbox or radio button element by Name
            // IList<IWebElement> CheckboxOptions = DriverUtils.driver.FindElements(By.Id("checkboxes"));
            // This will tell you the number of checkboxes are present
            IList<IWebElement> CheckboxOptions = HideColumnsOptions;
            int iSize = CheckboxOptions.Count;

            // Start the loop from first checkbox to last checkboxe
            for (int i = 0; i < iSize; i++)
            {
                // Store the checkbox name to the string variable, using 'Value' attribute
                 String Value = CheckboxOptions.ElementAt(i).GetAttribute("checked");
                Console.WriteLine("Value is \t" + Value);
                ////// Select the checkbox it the value of the checkbox is same what you are looking for
                // if (Value.Equals("Actions"))
                //{
                //    CheckboxOptions.ElementAt(i).Click();
                //    //Validations.validateElementIsPresent(ManageOrderTableHeader);
                //    Console.Write(DriverUtils.driver.FindElement(By.XPath("//*[@role='columnheader']")).Text);
                    
                //    // This will take the execution out of for loop
                //    break;
                //}
                //else
                //{
                //    Console.WriteLine("Option does not exist");
                //}
            }
        }
            }
}

        //// Step 3 : Select the deselected Radio button (female) for category Sex (Use IsSelected method)
        //// Storing all the elements under category 'Sex' in the list of WebLements	
        ////IList<IWebElement> CheckOptions = HideColumnsOptions;

        ////// Create a boolean variable which will hold the value (True/False)
        ////Boolean bValue = false;

        ////// This statement will return True, in case of first Radio button is selected
        ////bValue = CheckOptions.ElementAt(0).Selected;

        ////// This will check that if the bValue is True means if the first radio button is selected
        ////if (bValue == true)
        ////{
        ////    // This will select Second radio button, if the first radio button is selected by default
        ////    CheckOptions.ElementAt(1).Click();
        ////}
        ////else
        ////{
        ////    // If the first radio button is not selected by default, the first will be selected
        ////    CheckOptions.ElementAt(0).Click();
        ////}

    





 
