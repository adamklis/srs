using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumTestProject.Core
{
    public class Bookings
    {
        public IWebElement BookingsTable
        {
            get { return _driver.FindElement(By.Id("start_gwRezerwacje")); }
        }
        public IList<IWebElement> Rows
        {
            get { return BookingsTable.FindElements(By.TagName("tr")); }
            
        }
        public IWebElement LastRow
        {
            get { return Rows.Last(); }
        }
        private readonly IWebDriver _driver;

        public Bookings(IWebDriver driver)
        {
            _driver = driver;
        }

        public RowData GetRowData(IWebElement row)
        {
            var rowData = new RowData
            {
                Id = row.FindElements(By.TagName("td"))[0].Text,
                RoomName = row.FindElements(By.TagName("td"))[1].Text,
                LastName = row.FindElements(By.TagName("td"))[2].Text,
                FirstName = row.FindElements(By.TagName("td"))[3].Text,
                Contact = row.FindElements(By.TagName("td"))[4].Text,
                StartTime = row.FindElements(By.TagName("td"))[5].Text,
                EndTime = row.FindElements(By.TagName("td"))[6].Text,
                Comment = row.FindElements(By.TagName("td"))[7].Text,
                BtnDelete = row.FindElements(By.TagName("td"))[8]
            };
            return rowData;
        }

        public void DeleteLastRow()
        {
            var lastRow = GetRowData(LastRow);
            lastRow.BtnDelete.Click();
        }
    }
}