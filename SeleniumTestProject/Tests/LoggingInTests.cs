using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestProject.Core;

namespace SeleniumTestProject.Tests
{
    [TestClass]
    public class LoggingInTests
    {
        private static IWebDriver _driver;
        private static WebsiteHelper _websiteHelper;
        
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _driver = new FirefoxDriver();
            _websiteHelper = new WebsiteHelper(_driver);
        }

        [TestMethod]
        public void LoggingIn_CorrectLoginAndPassword_UserLoggedIn()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);

            Assert.AreEqual(_websiteHelper.LblLoggedInAs.Text, StringHelper.LoggedInAs);
            Assert.AreEqual(_websiteHelper.LblLoggedInSuccessfully.Text, StringHelper.LoggedInSuccessfully);
        }

        [TestMethod]
        public void LoggingOut_ClickLogOutOnMenu_UserLoggedOut()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);
            _websiteHelper.LogOut();
            Assert.AreEqual(_driver.Url, StringHelper.LogOutPageUrl);
        }

        [TestMethod]
        public void LoggingIn_WrongLogin_ErrorMessageShown()
        {
            _websiteHelper.LogIn(StringHelper.WrongLogin, StringHelper.DefaultPassword);
            Assert.AreEqual(_websiteHelper.LblLogInFailMessage.Text, StringHelper.LogInFailMessage);
        }

        [TestMethod]
        public void LoggingIn_WrongPassword_ErrorMessageShown()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.WrongPassword);
            Assert.AreEqual(_websiteHelper.LblLogInFailMessage.Text, StringHelper.LogInFailMessage);
        }

        [TestMethod]
        public void LoggingIn_WrongLoginAndPassword_ErrorMessageShown()
        {
            _websiteHelper.LogIn(StringHelper.WrongLogin, StringHelper.WrongPassword);
            Assert.AreEqual(_websiteHelper.LblLogInFailMessage.Text, StringHelper.LogInFailMessage);
        }

        [TestMethod]
        public void LoggingIn_EmptyLogin_ErrorMessageShown()
        {
            _websiteHelper.LogIn(string.Empty, StringHelper.DefaultPassword);
            Assert.IsTrue(_websiteHelper.IsErrorVisible(_websiteHelper.LblLoginError));
        }

        [TestMethod]
        public void LoggingIn_EmptyLoginAndPassword_ErrorMessageShown()
        {
            _websiteHelper.LogIn(string.Empty, string.Empty);
            Assert.IsTrue(_websiteHelper.IsErrorVisible(_websiteHelper.LblLoginError));
            Assert.IsTrue(_websiteHelper.IsErrorVisible(_websiteHelper.LblPasswordError));
        }

        [ClassCleanup]
        public static void Close()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}