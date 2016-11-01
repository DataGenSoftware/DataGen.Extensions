using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;

namespace DataGen.Extentions.UnitTests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void DateTimeBeginingOfDay_DateTime_ReturnsDateWithoutHoursMintesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.BeginingOfDay();

            DateTime expected = new DateTime(2016, 10, 30);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeEndOfDay_DateTime_ReturnsDateWithMaxHoursMinutesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.EndOfDay();

            DateTime expected = new DateTime(2016, 10, 30, 23, 59, 59, 999);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
            Assert.AreEqual(expected.Millisecond, actual.Millisecond);
        }

        [Test]
        public void DateTimeBeginingOfMonth_DateTime_ReturnsFirstDayOfMonthWithoutHoursMintesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.BeginingOfMonth();

            DateTime expected = new DateTime(2016, 10, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeEndOfMonth_DateTime_ReturnsLastDayOfMonthWithMaxHoursMinutesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.EndOfMonth();

            DateTime expected = new DateTime(2016, 10, 31, 23, 59, 59, 999);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
            Assert.AreEqual(expected.Millisecond, actual.Millisecond);
        }

        [Test]
        public void DateTimeFirstDayOfMonth_DateTime_ReturnsFirstDayOfMonthWithoutHoursMintesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.FirstDayOfMonth();

            DateTime expected = new DateTime(2016, 10, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeLastDayOfMonth_DateTime_ReturnsLastDayOfMonthWithoutHoursMintesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.LastDayOfMonth();

            DateTime expected = new DateTime(2016, 10, 31);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeBeginingOfYear_DateTime_ReturnsFirstDayOfyearWithoutHoursMintesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.BeginingOfYear();

            DateTime expected = new DateTime(2016, 1, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeEndOfYear_DateTime_ReturnsLastDayOfYearWithMaxHoursMinutesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.EndOfYear();

            DateTime expected = new DateTime(2016, 12, 31, 23, 59, 59, 999);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
            Assert.AreEqual(expected.Millisecond, actual.Millisecond);
        }

        [Test]
        public void DateTimeBeginingOfQuarter_DateTime_ReturnsFirstDayOfQuarterWithoutHoursMintesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.BeginingOfQuarter();

            DateTime expected = new DateTime(2016, 10, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeEndOfQuarter_DateTime_ReturnsLastDayOfQuarterWithMaxHoursMinutesEtc()
        {
            DateTime dateTime = new DateTime(2016, 10, 30, 12, 34, 56);

            DateTime actual = dateTime.EndOfQuarter();

            DateTime expected = new DateTime(2016, 12, 31, 23, 59, 59, 999);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
            Assert.AreEqual(expected.Millisecond, actual.Millisecond);
        }

        [TestCase(2016, 10, 30, 12, 34, 56, 0, 4)]
        [TestCase(2016, 1, 30, 12, 34, 56, 0, 1)]
        public void DateTimeQuarter_DateTime_ReturnsNumberOfQuarter(int year, int month, int day, int hour, int minute, int second, int milisecond, int quarter)
        {
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, milisecond);

            int actual = dateTime.Quarter();

            int expected = quarter;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("2016-10-30 12:34:56", 1, "2017-01-30 12:34:56")]
        [TestCase("2016-10-30 12:34:56", -1, "2016-07-30 12:34:56")]
        [TestCase("2016-03-31 12:34:56", 1, "2016-06-30 12:34:56")]
        public void DateTimeAddQuarters_DateTimeQuarters_ReturnsDateTime(string dateTimeString, int quarters, string newDateTimeString)
        {
            DateTime dateTime = DateTime.Parse(dateTimeString);

            DateTime actual = dateTime.AddQuarters(quarters);

            DateTime expected = DateTime.Parse(newDateTimeString);
            Assert.AreEqual(expected, actual);
        }
    }
}
