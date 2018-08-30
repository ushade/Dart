using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace ATF.PageOperations
{
    public class ManageUsersPage
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ManageUsersPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }

        //ManageUsers PageObjects
        [FindsBy(How = How.XPath, Using = "//a[@href='/COSWeb/ManageUser/UserManagement']")]
        public IWebElement ManageUsersTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Admin']/span/span")]
        public IWebElement AdminTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='createNewUser']")]
        public IWebElement CreateNewUserBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        public IWebElement SearchTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//h3[contains(.,'Manage Users')]")]
        public IWebElement ManageUsersTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='user_list_tbl_wrapper']")]
        public IWebElement ManageUsersTable { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@class='k-icon k-i-close']")]
        public IWebElement CreateUserCloseBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/thead/tr[@role='row']")]
        public IWebElement ManageUsersTableHeader { get; set; }
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[@class='bottom_border odd'][1]")]
        public IWebElement ManageUsersTableRow { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='fa fa-pencil-square fa-2x']")]
        public IWebElement EditUserBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='saveUser']")]
        public IWebElement SaveUserBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='createUser']")]
        public IWebElement CreateUserBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='k-widget k-dropdown k-header txt']")]
        public IWebElement UserRole { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[starts-with(@id,'userRole_') and contains(@id,'_listbox')]")]
        public IWebElement UserRoleOptions { get; set; }
        //   [FindsBy(How = How.XPath, Using = "//*[@id='userRole_listbox']/li")]
        //  public IList<IWebElement> UserRoleOptions { get; set; }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(),'Role')]")]
        public IWebElement RoleColumn { get; set; }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(),'Email')]")]
        public IWebElement EmailColumn { get; set; }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(),'First Name')]")]
        public IWebElement FirstNameColumn { get; set; }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(),'Last Name')]")]
        public IWebElement LastNameColumn { get; set; }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(),'Is Active')]")]
        public IWebElement IsActiveColumn { get; set; }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(),'Last Login')]")]
        public IWebElement LastLoginColumn { get; set; }
        // [FindsBy(How = How.XPath, Using = "//*[@id='userRole_listbox']/li")]
        //public IWebElement UserRoleOptions { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='userEmail']")]
        public IWebElement UserEmailTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='userActive']")]
        public IWebElement IsUserActiveCheckbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//div/label/select[@name='user_list_tbl_length']")]
        public IWebElement ShowFilterBtn { get; set; }
        //[FindsBy(How = How.Name, Using = "user_list_tbl_length")]
        //public SelectElement ShowFilterSelect { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='user_list_tbl_info']")]
        public IWebElement ManageUserTableInfo { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='user_list_tbl_paginate']")]
        public IWebElement ManageUserPaginateInfo { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='firstName']")]
        public IWebElement FirstNameField { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='lastName']")]
        public IWebElement LastNameField { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='userEmailError']")]
        public IWebElement userEmailErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='firstNameError']")]
        public IWebElement firstnameerrormsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='lastNameError']")]
        public IWebElement lastnameerrormsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='Usermessage']")]
        public IWebElement UserErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='userEmail']")]
        public IWebElement UserEmailTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='userRole']")]
        public IWebElement UserRoleTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='firstName']")]
        public IWebElement FirstnameTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='lastName']")]
        public IWebElement LastnameTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='userActive']")]
        public IWebElement IsUserActiveTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@id='Usermessage']")]
        public IWebElement GeneralErrorMsg { get; set; }



        public void SelectManageUsersTab()
        {
            DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            Console.WriteLine("In Manage Users Page");
            log.Info("In Manage users page");
            Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "In Manage Users Page");
        }


        public void CreateUserFunc(IWebElement UserEmailTextBox, String value, IWebElement UserRole, IWebElement UserRoleOptions,int ddloption, IWebElement FirstName, String fnamevalue, IWebElement LastName, String lnamevalue, IWebElement CreateBtn)
        {
            DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
           CreateNewUserBtn.Click();
            UserEmailTextBox.EnterText(value);
            BasicMethods.DropDownFunction(UserRole, UserRoleOptions, ddloption);
            FirstName.EnterText(fnamevalue);
            LastName.EnterText(lnamevalue);
            //IsUserActiveFlag.Click();
            //Validations.validateElementIsEnabled(CreateUserBtn);
            CreateUserBtn.Click();
            Thread.Sleep(5000);
           // CreateUserCloseBtn.Click();

        }
        public void EditUserFunc(String searchtext, IWebElement UserEmailTextBox, String value, IWebElement dropdownelement, IWebElement ddlistbox,int ddloption, IWebElement FirstName, String fnamevalue, IWebElement LastName, String lnamevalue, IWebElement IsUserActiveFlag, IWebElement SaveUserBtn)
        {
            DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            SearchTextBox.EnterText(searchtext);
            
            if (!string.IsNullOrEmpty(ManageUsersTableRow.Text) && (!string.IsNullOrWhiteSpace(ManageUsersTableRow.Text) && ManageUsersTableRow.Text.Contains(searchtext)))
            {
                Console.WriteLine("User data exist in the table" + ManageUsersTableRow.Text);
                EditUserBtn.Click();
                UserEmailTextBox.EnterText(value);
                BasicMethods.DropDownFunction(dropdownelement,ddlistbox,ddloption);
                FirstName.EnterText(fnamevalue);
                LastName.EnterText(lnamevalue);
                IsUserActiveFlag.Click();
                SaveUserBtn.Click();
                Thread.Sleep(8000);
                //CreateUserCloseBtn.Click();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Updated User Information!!");
                             
            }
            else
            {
                           
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("No record found", ExtentColor.Red)).AddScreenCaptureFromPath(s);
            }
        }
        public void SearchUser(IWebElement SearchTextBox, string searchuseremail)
        {
            //DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            SearchTextBox.EnterText(searchuseremail);
            if (!string.IsNullOrEmpty(ManageUsersTableRow.Text) && (!string.IsNullOrWhiteSpace(ManageUsersTableRow.Text) && ManageUsersTableRow.Text.Contains(searchuseremail)))
            {
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Given User\t" + searchuseremail + "\t record exist in the table");
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "Given User Details is as follows" + "\t" + ManageUsersTableRow.Text);
                log.Info("Given User\t" + searchuseremail + "\t record exist in the table");
            }
            else
            {
                Console.WriteLine(searchuseremail + "record not found in the table ");
                log.Info(searchuseremail + "\t" + "record not found in the table ");
                string s = BasicMethods.TakeScreenShot();
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel("Record not found", ExtentColor.Red)).AddScreenCaptureFromPath(s);
            }
        }

        public void ShowFilter(IWebElement element, string value, IWebElement showfilterelement, string msg)
        {
            //element.Click();
            BasicMethods.SelectDropdown(element, value);
            BasicMethods.VerifyPartialText(showfilterelement, msg);
        }

        public void SortFunc(IWebElement element, IWebElement firstrow, string ascendingmsg, string descendingmsg)
        {
            element.Click();
            Console.WriteLine("Descending Order");
            BasicMethods.VerifyPartialText(firstrow, descendingmsg);
            element.Click();
            Console.WriteLine("Ascending Order");
            BasicMethods.VerifyPartialText(firstrow, ascendingmsg);
        }
        public void EditUserNameTest(String searchtext, String useremail, IWebElement ManageUsersTableRow)
        {
            //DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            SearchTextBox.EnterText(searchtext);
            if (!string.IsNullOrEmpty(ManageUsersTableRow.Text) && (!string.IsNullOrWhiteSpace(ManageUsersTableRow.Text) && ManageUsersTableRow.Text.Contains(searchtext)))
            {
                Console.WriteLine(ManageUsersTableRow.Text);
                EditUserBtn.Click();
                UserEmailTextBox.EnterText(useremail);
                SaveUserBtn.Click();
                Thread.Sleep(2000);

            }
            else
            {
                Console.WriteLine(ManageUsersTableRow.Text);
                Console.WriteLine("User doesnt exist in the given table.");
            }
        }
        public void IsActiveUserFalseTest(String searchtext,IWebElement email,string value)
        {
            DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            Console.WriteLine("In Manage Users Page");
            SearchTextBox.EnterText(searchtext);
            if (ManageUsersTableRow.Text.Contains("false"))
            {
                Console.WriteLine("User is Inactive");
                EditUserBtn.Click();
                UserEmailTextBox.EnterText(value);
                SaveUserBtn.Click();
                Thread.Sleep(5000);
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "User is inactive");
            }
            else
            {
                Console.WriteLine("User is Active");
                Console.WriteLine(ManageUsersTableRow.Text);
                EditUserBtn.Click();
                UserEmailTextBox.EnterText(value);
                IsUserActiveCheckbox.Click();
                SaveUserBtn.Click();
                Thread.Sleep(5000);
                SearchTextBox.EnterText(searchtext);
                Console.WriteLine("User is now inactive");
                Console.WriteLine(ManageUsersTableRow.Text);
            }
        }

        public void IsActiveUserTrueTest(String searchtext, IWebElement email, string value)
        {
            DriverUtils.LaunchBrowser("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            Console.WriteLine("In Manage Users Page");
            SearchTextBox.EnterText(searchtext);
            if (ManageUsersTableRow.Text.Contains("true"))
            {
                Console.WriteLine("User is active");
                EditUserBtn.Click();
                UserEmailTextBox.EnterText(value);
                SaveUserBtn.Click();
                Thread.Sleep(5000);
                Common.ExtentReport.test.Log(AventStack.ExtentReports.Status.Pass, "User is active");
            }
            else
            {
                Console.WriteLine("User is InActive");
                Console.WriteLine(ManageUsersTableRow.Text);
                EditUserBtn.Click();
                UserEmailTextBox.EnterText(value);
                IsUserActiveCheckbox.Click();
                SaveUserBtn.Click();
                Thread.Sleep(5000);
                SearchTextBox.EnterText(searchtext);
                Console.WriteLine("User is now active");
                Console.WriteLine(ManageUsersTableRow.Text);
            }
        }
    }
}
