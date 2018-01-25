using OpenQA.Selenium;

namespace SeleniumTestProject.Core
{
    public class RowData
    {
        public string Id { get; set; }
        public string RoomName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Contact { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Comment { get; set; }
        public IWebElement BtnDelete { get; set; }
    }
}