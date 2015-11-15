using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGen.Extensions;

namespace DataGen.Extensions.Tests
{
	[TestClass]
	public class DateTimeTests
	{
		[TestMethod]
		public void IsWeekendDayTest()
		{
			DateTime date;
			bool actual;

			date = new DateTime(2015, 9, 4);
			actual = date.IsWeekendDay();
			Assert.IsFalse(actual);

			date = new DateTime(2015, 9, 5);
			actual = date.IsWeekendDay();
			Assert.IsTrue(actual);

			date = new DateTime(2015, 9, 6);
			actual = date.IsWeekendDay();
			Assert.IsTrue(actual);

			date = new DateTime(2015, 9, 7);
			actual = date.IsWeekendDay();
			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void IsWeekDayTest()
		{
			DateTime date;
			bool actual;

			date = new DateTime(2015, 9, 4);
			actual = date.IsWeekDay();
			Assert.IsTrue(actual);

			date = new DateTime(2015, 9, 5);
			actual = date.IsWeekDay();
			Assert.IsFalse(actual);

			date = new DateTime(2015, 9, 6);
			actual = date.IsWeekDay();
			Assert.IsFalse(actual);

			date = new DateTime(2015, 9, 7);
			actual = date.IsWeekDay();
			Assert.IsTrue(actual);
		}

		[TestMethod]
		public void BeginingOfDayTest()
		{
			DateTime date, actual, expected;

			date = new DateTime(2015, 9, 3, 13, 14, 11, 25);
			actual = date.BeginingOfDay();
			expected = new DateTime(2015, 9, 3, 0, 0, 0, 0);
			Assert.AreEqual(expected, actual);

			date = new DateTime(2015, 9, 4, 2, 23, 45, 1);
			actual = date.BeginingOfDay();
			expected = new DateTime(2015, 9, 4, 0, 0, 0, 0);
			Assert.AreEqual(expected, actual);

			date = new DateTime(2015, 9, 5, 19, 28, 1, 12);
			actual = date.BeginingOfDay();
			expected = new DateTime(2015, 9, 5, 0, 0, 0, 0);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void EndOfDayTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void BeginingOfMonthTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void EndOfMonthTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void FirstDayOfMonthTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void LastDayOfMonthTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void BeginingOfWeekTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void EndOfWeekTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void IsTodayTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void AddWeeksTest()
		{
			DateTime date, actual, expected;

			date = new DateTime(2015, 9, 5);
			actual = date.AddWeeks(1);
			expected = new DateTime(2015, 9, 12);
			Assert.AreEqual(expected, actual);

			date = new DateTime(2015, 9, 5);
			actual = date.AddWeeks(3);
			expected = new DateTime(2015, 9, 26);
			Assert.AreEqual(expected, actual);

			date = new DateTime(2015, 9, 5);
			actual = date.AddWeeks(13);
			expected = new DateTime(2015, 12, 5);
			Assert.AreEqual(expected, actual);

			date = new DateTime(2015, 9, 5);
			actual = date.AddWeeks(-2);
			expected = new DateTime(2015, 8, 22);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BeginingOfYearTest()
		{
			Assert.Fail();
		}

		[TestMethod]
		public void EndOfYearTest()
		{
			Assert.Fail();
		}
	}
}
