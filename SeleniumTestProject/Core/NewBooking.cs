using OpenQA.Selenium;

namespace SeleniumTestProject.Core
{
    public class NewBooking
    {
        
        public IWebElement DdlRoom { get { return _driver.FindElement(By.Id("start_ddlSale")); } }
        public IWebElement DdlRoom421N
        {
            get
            {
                return _driver.FindElement(By.XPath(
                    "html/body/form/table/tbody/tr[2]/td[2]/div/section/table/tbody/tr[1]/td/select/option[4]"));
            }
        }
        public IWebElement TbStartDate { get { return _driver.FindElement(By.Id("start_tbDataOd")); } }
        public IWebElement TbStartTime { get { return _driver.FindElement(By.Id("start_tbCzasOd")); } }
        public IWebElement TbEndDate { get { return _driver.FindElement(By.Id("start_tbDataDo")); } }
        public IWebElement TbEndTime { get { return _driver.FindElement(By.Id("start_tbCzasDo")); } }
        public IWebElement TbComment { get { return _driver.FindElement(By.Id("start_tbKomentarz")); } }
        public IWebElement BtnBook { get { return _driver.FindElement(By.Id("start_btRezerwuj")); } }
        public IWebElement TbStartDateValidator { get { return _driver.FindElement(By.Id("start_rfvTbCzasOd")); } }
        public IWebElement TbStartTimeValidator { get { return _driver.FindElement(By.Id("start_rfvTbCzasOd")); } }
        public IWebElement TbEndDateValidator { get { return _driver.FindElement(By.Id("start_rfvTbDataDo")); } }
        public IWebElement TbEndTimeValidator { get { return _driver.FindElement(By.Id("start_rfvTbCzasDo")); } }
        public IWebElement BookingValidator { get { return _driver.FindElement(By.Id("start_lblBlad")); } }

        public NewBooking(IWebDriver driver)
        {
          _driver = driver;
        }

        private readonly IWebDriver _driver;

        public void CreateBooking(BookingInfo info)
        {
            DdlRoom421N.Click();
            TbStartDate.SendKeys(info.StartDate);
            TbStartTime.SendKeys(info.StartTime);
            TbEndDate.SendKeys(info.EndDate);
            TbEndTime.SendKeys(info.EndTime);
            TbComment.SendKeys(info.Comment);
            BtnBook.Click();
        }
    }
}

