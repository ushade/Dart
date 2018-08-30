using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATF.PageOperations;

namespace ATF.TestCases
{
   public class ManageUsersRegressionTest : ATF.Common.ExtentReport
    {
        [SetUp]
        public void LaunchBrowser()
        {
            String url = "http://cos-test.psr.rd.hpicorp.net/COSWeb/";
            Console.WriteLine("Opening url");
            DriverUtils.opendriver(DriverUtils.Browser.IE);
            DriverUtils.LaunchBrowser(url);

        }
        [TearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("closing browser");
            extent.Flush();
            DriverUtils.driver.Quit();
        }
        [Test]
        public void ManageUsersUITest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Verify UI elements in manage users page");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.SelectManageUsersTab();
            Validations.validateScreenByUrl("http://cos-test.psr.rd.hpicorp.net/COSWeb/ManageUser/UserManagement");
            BasicMethods.VerifyText(ManageUser.ManageUsersTitle, "Manage Users");
            Validations.validateElementIsPresent(ManageUser.CreateNewUserBtn);
            Validations.validateElementIsPresent(ManageUser.EditUserBtn);
            Validations.validateElementIsEnabled(ManageUser.SearchTextBox);
            Validations.validateElementIsPresent(ManageUser.ShowFilterBtn);
            Validations.validateElementIsPresent(ManageUser.ManageUsersTable);
            BasicMethods.VerifyText(ManageUser.ManageUsersTableHeader, "Role Email First Name Last Name Is Active Last Login Edit User");
            Validations.validateElementIsPresent(ManageUser.ManageUserTableInfo);
            Validations.validateElementIsPresent(ManageUser.ManageUserPaginateInfo);
        }
        [Test]
        public void CreateUserFunctionalityTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test create user functionality");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 0, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.CreateUserBtn);
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh.govindan@hp.com");
            
         }
        [Test]
        public void EditUserFunctionalityTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test edit user functionality");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh.govindan@hp.com");
        }
        [Test]
        public void SearchUserFunctionalityTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test search user functionality");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.SelectManageUsersTab();
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.SearchUser(ManageUser.SearchTextBox, "Navaneeth");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "Admin navaneetha.krishnan1@hp.com Navaneetha Krishnan true");
        }
        [Test]
        public void ShowFilterFunctionalityTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test show filter functionality");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.SelectManageUsersTab();
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.ShowFilter(ManageUser.ShowFilterBtn, "100", ManageUser.ManageUserTableInfo, "Showing 1 to 14 of 14 entries");
            ManageUser.ShowFilter(ManageUser.ShowFilterBtn, "10", ManageUser.ManageUserTableInfo, "Showing 1 to 10 of 14 entries");
            ManageUser.ShowFilter(ManageUser.ShowFilterBtn, "25", ManageUser.ManageUserTableInfo, "Showing 1 to 14 of 14 entries");
            ManageUser.ShowFilter(ManageUser.ShowFilterBtn, "50", ManageUser.ManageUserTableInfo, "Showing 1 to 14 of 14 entries");
            
        }
        [Test]
        public void SortFunctionalityTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test sort functionality");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.SelectManageUsersTab();
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.SortFunc(ManageUser.RoleColumn, ManageUser.ManageUsersTableRow,"Admin", "Requester");
            ManageUser.SortFunc(ManageUser.EmailColumn, ManageUser.ManageUsersTableRow, "usha.devaraj@hp.com", "angel.valdez@hp.com");
            ManageUser.SortFunc(ManageUser.FirstNameColumn, ManageUser.ManageUsersTableRow, "Usha", "Angel");
            ManageUser.SortFunc(ManageUser.LastNameColumn, ManageUser.ManageUsersTableRow, "Valdez", "Amanullah");
            ManageUser.SortFunc(ManageUser.IsActiveColumn, ManageUser.ManageUsersTableRow, "true", "false");
            ManageUser.SortFunc(ManageUser.LastLoginColumn, ManageUser.ManageUsersTableRow, "NA", "03/09/2018 08:11:25 AM");
        }
        [Test]
        public void BlankValuesTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test error messages with blank values in create user popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.SelectManageUsersTab();
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.CreateNewUserBtn.Click();
            ManageUser.CreateUserBtn.Click();
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Email should not be empty.");
            BasicMethods.VerifyText(ManageUser.firstnameerrormsg, "First Name should not be empty.");
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not be empty.");
            ManageUser.CreateUserCloseBtn.Click();

        }
        [Test]
        public void checkDefaultvalues()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "check Default values and mandatory fields in create user popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.SelectManageUsersTab();
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            ManageUser.CreateNewUserBtn.Click();
            BasicMethods.DefaultValue(ManageUser.UserEmailTextBox);
            BasicMethods.VerifyText(ManageUser.UserRole, "Requester");
            BasicMethods.DefaultValue(ManageUser.FirstNameField);
            BasicMethods.DefaultValue(ManageUser.LastNameField);
            BasicMethods.CheckBox(ManageUser.IsUserActiveCheckbox);
            BasicMethods.VerifyText(ManageUser.UserEmailTitle, "Email *");
            BasicMethods.VerifyText(ManageUser.UserRoleTitle, "User Role");
            BasicMethods.VerifyText(ManageUser.FirstnameTitle, "First Name *");
            BasicMethods.VerifyText(ManageUser.LastnameTitle, "Last Name *");
            BasicMethods.VerifyText(ManageUser.IsUserActiveTitle, "Is User Active?");
            ManageUser.CreateUserCloseBtn.Click();
        }
        [Test]
        public void EmailFieldErrorValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Error validation in email field in create user popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "!@#$%^&*()", ManageUser.UserRole, ManageUser.UserRoleOptions,1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Please provide a valid email address");
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "a@a.com", ManageUser.UserRole, ManageUser.UserRoleOptions,1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Please enter a valid HP Email Id.");
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.GeneralErrorMsg, "Email is already exists.");
         
        }
        [Test]
        public void UserRoleFieldValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Test with the available options in user role field");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions,1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh.govindan@hp.com");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "Admin kumaresh.govindan@hp.com");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 0, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh.govindan@hp.com");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "Requester kumaresh.govindan@hp.com");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 2, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh.govindan@hp.com");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "EHSManager kumaresh.govindan@hp.com");
        }
        [Test]
        public void FirstNameFieldErrorValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Error validation in firstname field in create user popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, " ", ManageUser.LastNameField, "Govindan", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.firstnameerrormsg, "First Name should not be empty.");
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "****", ManageUser.LastNameField, "Govindan", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.firstnameerrormsg, "First Name should not contain anything except letters and spaces.");
            
        }
        [Test]
        public void LastNameFieldErrorValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Error validation in lastname field in create user popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not be empty.");
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "$$$$@#@", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not contain anything except letters and spaces.");
            ManageUser.CreateUserFunc(ManageUser.UserEmailTextBox, "a@a.com", ManageUser.UserRole, ManageUser.UserRoleOptions,1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "*****", ManageUser.CreateUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Please enter a valid HP Email Id.");
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not contain anything except letters and spaces.");

        }
        [Test]
        public void EditUserEmailFieldErrorValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Error validation in email field in EditUser popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "david.espinoza@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.GeneralErrorMsg, "Email is already exists.");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "", ManageUser.UserRole, ManageUser.UserRoleOptions,1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Email should not be empty.");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "!@#$%^&*()", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Please provide a valid email address");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "a@a.com", ManageUser.UserRole, ManageUser.UserRoleOptions,1, ManageUser.FirstNameField, "Kumaresh", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Please enter a valid HP Email Id.");
            
        }
       [Test]
        public void EditUserFirstNameFieldErrorValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Error validation in firstname field in EditUser popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.firstnameerrormsg, "First Name should not be empty.");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "****", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.firstnameerrormsg, "First Name should not contain anything except letters and spaces.");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "K", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "K Govindan");
            ManageUser.EditUserFunc("kumaresh", ManageUser.UserEmailTextBox, "kumaresh.govindan@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 2, ManageUser.FirstNameField, "Kumaresh ", ManageUser.LastNameField, "Govindan", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "kumaresh");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "Kumaresh ");
        }
        [Test]
        public void EditUserLastNameFieldErrorValidation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Error validation in lastname field in EditUser popup message");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.EditUserFunc("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 2, ManageUser.FirstNameField, "Durga", ManageUser.LastNameField, "", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not be empty.");
            ManageUser.EditUserFunc("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 2, ManageUser.FirstNameField, "Durga", ManageUser.LastNameField, "$$$$@#@", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not contain anything except letters and spaces.");
            ManageUser.EditUserFunc("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions,2, ManageUser.FirstNameField, "Durga", ManageUser.LastNameField, "Prasad", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "Durga");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "Durga Prasad");
            ManageUser.EditUserFunc("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 2, ManageUser.FirstNameField, "Durga", ManageUser.LastNameField, "Prasad Palukuri ", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            ManageUser.SearchUser(ManageUser.SearchTextBox, "Durga");
            BasicMethods.VerifyPartialText(ManageUser.ManageUsersTableRow, "Durga Prasad Palukuri ");
            ManageUser.EditUserFunc("durga", ManageUser.UserEmailTextBox, "a@a.com", ManageUser.UserRole, ManageUser.UserRoleOptions, 1, ManageUser.FirstNameField, "Durga", ManageUser.LastNameField, "**** ", ManageUser.IsUserActiveCheckbox, ManageUser.SaveUserBtn);
            BasicMethods.VerifyText(ManageUser.userEmailErrorMsg, "Please enter a valid HP Email Id.");
            BasicMethods.VerifyText(ManageUser.lastnameerrormsg, "Last Name should not contain anything except letters and spaces.");

        }
        [Test]
        public void ActiveUserTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "ActiveUserTest");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            var HomePage = new HomePage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.IsActiveUserTrueTest("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com");
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            BasicMethods.ClickBtn(HomePage.LogOffBtn);
           LoginPage.Login(LoginPage.UserName, "durga-prasad.palukuri@hp.com", LoginPage.Password, "Lost4now", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
          
        }
         
        [Test]
        public void InActiveUserTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Inactive user test");
            var LoginPage = new LoginPage();
            var ManageUser = new ManageUsersPage();
            var HomePage = new HomePage();
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.IsActiveUserFalseTest("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com");
            Validations.validateTitle("Manage Users - Chemical Ordering Tool");
            BasicMethods.ClickBtn(HomePage.LogOffBtn);
            LoginPage.Login(LoginPage.UserName, "durga-prasad.palukuri@hp.com", LoginPage.Password, "Lost4now", LoginPage.LoginInBtn, LoginPage.Welcometitle);
            BasicMethods.VerifyText(LoginPage.BlankErrorMsg, "Sorry, you are not an active user for this website.");
            LoginPage.Login(LoginPage.UserName, "usha.devaraj@hp.com", LoginPage.Password, "July012018", LoginPage.LoginInBtn, LoginPage.Last10RequestsTitle);
            ManageUser.IsActiveUserTrueTest("durga", ManageUser.UserEmailTextBox, "durga-prasad.palukuri@hp.com");

        }













    }
}
