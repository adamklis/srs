using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestProject.Core;

namespace SeleniumTestProject.Tests
{
    [TestClass]
    public class BookingTests
    {
        private static WebsiteHelper _websiteHelper;
        private static ControlHelper _controlHelper;
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _driver = new FirefoxDriver();
            _websiteHelper = new WebsiteHelper(_driver);
            _controlHelper = new ControlHelper();
        }


        [TestMethod]
        public void AddBooking_AddBookingWithCorrectData_CheckBookingData()
        {

            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);
            _websiteHelper.MainMenu.NewBooking.Click();
            _websiteHelper.NewBooking.CreateBooking(new BookingInfo
            {
                StartDate = "2020-10-10",
                StartTime = "10:00",
                EndDate = "2020-10-10",
                EndTime = "11:30",
                Comment = StringHelper.Comment
            });
            _websiteHelper.MainMenu.Bookings.Click();
            var rowData = _websiteHelper.Bookings.GetRowData(_websiteHelper.Bookings.LastRow);
            Assert.AreEqual(StringHelper.Room421N, rowData.RoomName);
            Assert.AreEqual(StringHelper.LastName, rowData.LastName);
            Assert.AreEqual(StringHelper.FirstName, rowData.FirstName);
            Assert.AreEqual(StringHelper.Contact, rowData.Contact);
            Assert.AreEqual(StringHelper.StartTime, rowData.StartTime);
            Assert.AreEqual(StringHelper.EndTime, rowData.EndTime);
            Assert.AreEqual(StringHelper.Comment, rowData.Comment);

            rowData.BtnDelete.Click();
            
            _websiteHelper.LogOut();

        }

        [TestMethod]
        public void AddBooking_AddBookingWithCorrectData_CheckBookingsAmount()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);
            _websiteHelper.MainMenu.Bookings.Click();
            var rowsCountBefore = _websiteHelper.Bookings.Rows.Count;
            _websiteHelper.MainMenu.NewBooking.Click();
            _websiteHelper.NewBooking.CreateBooking(new BookingInfo
            {
                StartDate = "2020-10-10",
                StartTime = "10:00",
                EndDate = "2020-10-10",
                EndTime = "11:30",
                Comment = StringHelper.Comment
            });
            _websiteHelper.MainMenu.Bookings.Click();
            var rowsCountAfter = _websiteHelper.Bookings.Rows.Count;

            Assert.IsTrue(rowsCountBefore + 1 == rowsCountAfter);

            _websiteHelper.Bookings.DeleteLastRow();
            _websiteHelper.LogOut();

        }

        [TestMethod]
        public void AddBooking_AddBookingWithNoData_ValidatorsFired()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);
            _websiteHelper.MainMenu.NewBooking.Click();
            _websiteHelper.NewBooking.BtnBook.Click();
            var tbStartDateValidatorFired = _controlHelper.IsValidatorFired(_websiteHelper.NewBooking.TbStartDateValidator);
            var tbStartTimeValidatorFired = _controlHelper.IsValidatorFired(_websiteHelper.NewBooking.TbStartTimeValidator);
            var tbEndDateValidatorFired = _controlHelper.IsValidatorFired(_websiteHelper.NewBooking.TbEndDateValidator);
            var tbEndTimeValidatorFired = _controlHelper.IsValidatorFired(_websiteHelper.NewBooking.TbEndTimeValidator);
            Assert.IsTrue(tbStartDateValidatorFired);
            Assert.IsTrue(tbStartTimeValidatorFired);
            Assert.IsTrue(tbEndDateValidatorFired);
            Assert.IsTrue(tbEndTimeValidatorFired);

            _websiteHelper.LogOut();
        }

        [TestMethod]
        public void AddBooking_AddBookingWithNoData_NoNewBooking()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);
            _websiteHelper.MainMenu.Bookings.Click();
            var bookingsAmountBefore = _websiteHelper.Bookings.Rows.Count;
            _websiteHelper.MainMenu.NewBooking.Click();
            _websiteHelper.NewBooking.BtnBook.Click();
            _websiteHelper.MainMenu.Bookings.Click();
            var bookingsAmountAfter =_websiteHelper.Bookings.Rows.Count;
            
            Assert.AreEqual(bookingsAmountBefore, bookingsAmountAfter);

            _websiteHelper.LogOut();
        }

        [TestMethod]
        public void AddBooking_AddBookingTwice_NoNewBooking()
        {
            _websiteHelper.LogIn(StringHelper.DefaultLogin, StringHelper.DefaultPassword);
            _websiteHelper.MainMenu.Bookings.Click();
            var bookingsAmountBefore = _websiteHelper.Bookings.Rows.Count;
            _websiteHelper.MainMenu.NewBooking.Click();
            _websiteHelper.NewBooking.CreateBooking(new BookingInfo
            {
                StartDate = "2020-10-10",
                StartTime = "10:00",
                EndDate = "2020-10-10",
                EndTime = "11:30",
                Comment = StringHelper.Comment
            });
            _websiteHelper.NewBooking.BtnBook.Click();
            _websiteHelper.NewBooking.BtnBook.Click();
            
            Assert.AreEqual(StringHelper.RoomAlreadyBooked, _websiteHelper.NewBooking.BookingValidator.Text);

            _websiteHelper.MainMenu.Bookings.Click();
            var bookingsAmountAfter = _websiteHelper.Bookings.Rows.Count;

            Assert.AreEqual(bookingsAmountBefore + 1, bookingsAmountAfter);

           _websiteHelper.Bookings.DeleteLastRow();
            _websiteHelper.LogOut();
        }

        [ClassCleanup]
        public static void Close()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
