using OpenQA.Selenium;

namespace SeleniumTestProject.Core
{
    public class WebsiteHelper
    {
        #region Controls
        public IWebElement TbLogin
        {
            get { return _driver.FindElement(By.Id("start_tbLogin")); }
        }
        public IWebElement TbPassword
        {
            get { return _driver.FindElement(By.Id("start_tbHaslo")); }
        }
        public IWebElement BtnZaloguj
        {
            get { return _driver.FindElement(By.Id("start_btZaloguj")); }
        }
        public IWebElement LblLoginError { get { return _driver.FindElement(By.Id("start_LoginRFV")); } }
        public IWebElement LblPasswordError { get { return _driver.FindElement(By.Id("start_HasloRFV")); } }
        public IWebElement LblLoggedInAs
        {
            get
            {
                return _driver.FindElement(By.Id("lbl_userInfo"));
                
            }
        }
        public IWebElement LblLoggedInSuccessfully
        {
            get { return _driver.FindElement(By.XPath("/html/body/form/table/tbody/tr[2]/td[2]/div/section")); }
        }
        public IWebElement LblLogInFailMessage { get { return _driver.FindElement(By.Id("start_LoginCV")); } }

        public MainMenu MainMenu { get; }
        public NewBooking NewBooking { get; }
        public Bookings Bookings { get; }

        #endregion
        
        private readonly IWebDriver _driver;

        public WebsiteHelper(IWebDriver driver)
        {
            _driver = driver;
            MainMenu = new MainMenu(driver);
            NewBooking = new NewBooking(driver);
            Bookings = new Bookings(driver);
        }

        public void LogIn(string login, string password)
        {
            _driver.Navigate().GoToUrl(StringHelper.LogInPageUrl);
            TbLogin.Clear();
            TbLogin.SendKeys(login);
            TbPassword.Clear();
            TbPassword.SendKeys(password);
            BtnZaloguj.Click();
        }

        public void LogOut()
        {
            MainMenu.LogOut.Click();
        }

        public bool IsErrorVisible(IWebElement errorMessage)
        {
            return errorMessage.GetAttribute("style") == "color: red; visibility: visible;";
        }

    }
}
