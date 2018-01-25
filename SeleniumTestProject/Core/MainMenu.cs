using OpenQA.Selenium;

namespace SeleniumTestProject.Core
{
    public class MainMenu
    {
        public IWebElement LogOut
        {
            get { return _driver.FindElement(By.LinkText("Wyloguj")); }
        }
        public IWebElement NewBooking
        {
            get { return _driver.FindElement(By.LinkText("Nowa Rezerwacja")); }
        }
        public IWebElement Bookings
        {
            get
            {
                return _driver.FindElement(By.LinkText("Rezerwacje"));
            }
        }
        public IWebElement Rooms
        {
            get { return _driver.FindElement(By.LinkText("Sale")); }
        }
        public IWebElement Tools
        {
            get { return _driver.FindElement(By.LinkText("Sprzêt")); }
        }
        public IWebElement Software
        {
            get { return _driver.FindElement(By.LinkText("Oprogramowanie")); }
        }
        public IWebElement Users
        {
            get { return _driver.FindElement(By.LinkText("U¿ytkownicy")); }
        }
        private readonly IWebDriver _driver;

        public MainMenu(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}