using DataGen.Extensions.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
	public static class DateTimeExtensions
	{
		private static DayOfWeek FirstDayOfWeek()
		{
			return DateTimeProvider.Current.FirstDayOfWeek;
		}

		private static IEnumerable<DayOfWeek> WeekendDays()
		{
			return DateTimeProvider.Current.WeekendDays;
		}

		public static bool IsWeekendDay(this DateTime value)
		{
			return WeekendDays().Contains(value.DayOfWeek);
		}

		public static bool IsWeekDay(this DateTime value)
		{
			return !DateTimeExtensions.IsWeekendDay(value);
		}

		public static DateTime BeginingOfDay(this DateTime value)
		{
			return value.Date;
		}

		public static DateTime EndOfDay(this DateTime value)
		{
			return value.Date.AddDays(1).AddTicks(-1);
		}

		public static DateTime BeginingOfMonth(this DateTime value)
		{
			return new DateTime(value.Year, value.Month, 1);
		}

		public static DateTime EndOfMonth(this DateTime value)
		{
			return value.BeginingOfMonth().AddMonths(1).AddTicks(-1);
		}

		public static DateTime FirstDayOfMonth(this DateTime value)
		{
			return new DateTime(value.Year, value.Month, 1);
		}

		public static DateTime LastDayOfMonth(this DateTime value)
		{
			return value.FirstDayOfMonth().AddMonths(1).AddDays(-1);
		}

		public static DateTime BeginingOfWeek(this DateTime value, DayOfWeek firstDayOfWeek)
		{
			int daysOffset = firstDayOfWeek - value.DayOfWeek;
			return value.AddDays(daysOffset).Date;
		}

		public static DateTime BeginingOfWeek(this DateTime value)
		{
			return value.BeginingOfWeek(FirstDayOfWeek());
		}

		public static DateTime EndOfWeek(this DateTime value, DayOfWeek firstDayOfWeek)
		{
			return value.BeginingOfWeek(firstDayOfWeek).AddWeeks(1).AddTicks(-1);
		}

		public static DateTime EndOfWeek(this DateTime value)
		{
			return value.EndOfWeek(FirstDayOfWeek());
		}

		public static bool IsToday(this DateTime value)
		{
			return value.Date == DateTimeProvider.Current.Today;
		}

		public static bool IsFuture(this DateTime value)
		{
			return value > DateTimeProvider.Current.Now;
		}

		public static bool IsPast(this DateTime value)
		{
			return value < DateTimeProvider.Current.Now;
		}

		public static DateTime AddWeeks(this DateTime value, int count)
		{
			return value.AddDays(7 * count);
		}

		public static DateTime BeginingOfYear(this DateTime value)
		{
			return new DateTime(value.Year, 1, 1);
		}

		public static DateTime EndOfYear(this DateTime value)
		{
			return value.BeginingOfYear().AddYears(1).AddTicks(-1);
		}

		public static int Quarter(this DateTime value)
		{
			return (value.Month + 2) / 3;
		}

		public static DateTime AddQuarters(this DateTime value, int count)
		{
			return value.AddMonths(3 * count);
		}

		public static DateTime BeginingOfQuarter(this DateTime value)
		{
			return new DateTime(value.Year, 1, 1).AddQuarters(value.Quarter() - 1);
		}

		public static DateTime EndOfQuarter(this DateTime value)
		{
			return value.BeginingOfQuarter().AddQuarters(1).AddTicks(-1);
		}

		public static IList<DateTime> DaysToDate(this DateTime value, DateTime toDate)
		{
            var daysToDate = new List<DateTime>();
            value = value.Ceiling(new TimeSpan(1, 0, 0, 0));

            while (value <= toDate)
			{
				daysToDate.Add(value);
                value = value.AddDays(1);
            }

            return daysToDate;
		}

        public static IList<DateTime> HoursToDate(this DateTime value, DateTime toDate)
        {
            var hoursToDate = new List<DateTime>();
            value = value.Ceiling(new TimeSpan(1, 0, 0));
            
            while (value <= toDate)
            {
                hoursToDate.Add(value);
                value = value.AddHours(1);
            }

            return hoursToDate;
        }

        private static DateTime Ceiling(this DateTime value, TimeSpan interval)
        {
            var rest = value.Ticks % interval.Ticks;
            return rest >= 0 ? value.AddTicks(interval.Ticks - rest) :value;
        }
    }
}
