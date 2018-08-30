using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ATF.PageOperations;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System.IO;

namespace ATF
{
    
    public class LoginPageRegressionTest : ATF.Common.ExtentReport
    {
       protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       
        [SetUp]
        public void LaunchBrowser()
        {
            String url = "http://cos-test.psr.rd.hpicorp.net/COSWeb/";
            Console.WriteLine("Opening url");
            DriverUtils.opendriver(DriverUtils.Browser.IE);
            DriverUtils.driver.Navigate().GoToUrl(url);
            DriverUtils.driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void CloseBrowser()
        {
            extent.Flush();
            DriverUtils.driver.Quit();
        }

        [Test]
        public void LoginPageUITest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Verify UI");
            var LoginPage = new LoginPage();
            var ManageUsers = new ManageUsersPage();
            var HomePage = new HomePage();
            BasicMethods.CheckImage(LoginPage.HPLogo);
            BasicMethods.VerifyPartialText(LoginPage.Welcometitle, "Chemical Ordering Tool - HP Inc.");
            BasicMethods.VerifyText(LoginPage.WelcomeHeader, "Welcome to the Chemical Ordering Tool");
            BasicMethods.VerifyText(LoginPage.WelcomeBanner, "This is a private tool. Explicit authorization from the tool owner is required for access or use. Unauthorized access or use may result in severe civil and/or criminal liability including without limitation under 18 USC Sections 1030 et seq. All rights whatsoever are reserved.");
            BasicMethods.VerifyText(LoginPage.LoginFormTitle, "Please log in using your HP Email and Password");
            BasicMethods.VerifyText(LoginPage.ContactusLink, "Please contact COT Support (COS-Support@hp.com) if you have questions.");
        }
        [Test]
        public void BlankCredentialsTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Login Page with blank values");
            var LoginPage = new LoginPage();
            LoginPage.Login(LoginPage.UserName, "", LoginPage.Password, "", LoginPage.LoginInBtn, LoginPage.Welcometitle);
            BasicMethods.VerifyPartialText(LoginPage.BlankErrorMsg, "The Password field is required.");
            BasicMethods.VerifyText(LoginPage.BlankEmailErrorMsg, "The Email field is required.");
            BasicMethods.VerifyText(LoginPage.BlankPasswordErrorMsg, "The Password field is required.");
            BasicMethods.VerifyText(LoginPage.EmailErrorMsg, "The Email field is required.");
            BasicMethods.VerifyText(LoginPage.PasswordErrorMsg, "The Password field is required.");
           
        }
        [Test]
        public void InvalidEmailTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Login Page with invalid email and valid password ");
            var LoginPage = new LoginPage();
            LoginPage.Login(LoginPage.UserName, "usha", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Welcometitle);
            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "The Email field is not a valid e-mail address.");
            BasicMethods.VerifyText(LoginPage.EmailErrorMsg, "The Email field is not a valid e-mail address.");
        }
        [Test]
        public void InvalidPasswordTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Login Page with valid email and invalid password ");
            var LoginPage = new LoginPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July2018", LoginPage.LoginInBtn, LoginPage.Welcometitle);
            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "The email address or password provided is incorrect. Please try again.");
           
        }
        [Test]
        public void InvalidcredentialsTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Login Page with invalid email and invalid password ");
            var LoginPage = new LoginPage();
            LoginPage.Login(LoginPage.UserName, "x@u.com", LoginPage.Password, "xxxxxx", LoginPage.LoginInBtn, LoginPage.Welcometitle);
            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "The email address or password provided is incorrect. Please try again.");
        }
        [Test]
        public void validcredentialsTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Login Page with valid email and valid password ");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            BasicMethods.ClickBtn(HomePage.LogOffBtn);
        }
        [Test]
        public void UnauthorizedAccessTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test Login Page with unauthorized user credentials ");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.EditUserFunc("Durga", ManageUser.UserEmailTextBox, "suraj.sarangamath@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 2, ManageUser.FirstNameField, "Durga Prasad", ManageUser.LastNameField, "Palukuri", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.IsActiveUserTrueTest("Durga Prasad", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com");
            BasicMethods.ClickBtn(HomePage.LogOffBtn);
            LoginPage.Login(LoginPage.UserName, "durga-prasad.palukuri@hp.com", LoginPage.Password, "Lost4now", LoginPage.LoginInBtn,LoginPage.Welcometitle);
            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "Sorry, you do not have access to this website.");

        }
        [Test]
        public void UserAccountActiveTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Scenario to check if the user account is active or inactive ");
            var LoginPage = new LoginPage();
            var HomePage = new HomePage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
           // ManageUser.EditUserNameTest("Durga Prasad", "durga-prasad.palukuri@hp.com", ManageUser.ManageUsersTableRow);
            ManageUser.IsActiveUserFalseTest("Durga Prasad", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com");
            BasicMethods.ClickBtn(HomePage.LogOffBtn);
            LoginPage.Login(LoginPage.UserName, "durga-prasad.palukuri@hp.com", LoginPage.Password, "Lost4now", LoginPage.LoginInBtn, LoginPage.Welcometitle);
            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "Sorry, you are not an active user for this website.");
        }
 }
}