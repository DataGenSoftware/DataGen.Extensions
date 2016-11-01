using DataGen.Extensions.Contracts;
using System;
using System.Collections.Generic;

namespace DataGen.Extensions.Providers
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public virtual DateTime Now
        {
            get
            {
                return DateTime.Now;
            }

        }

        public virtual DateTime Today
        {
            get
            {
                return DateTime.Today;
            }

        }

        public virtual DayOfWeek FirstDayOfWeek
        {
            get
            {
                return DayOfWeek.Monday;
            }
        }

        public virtual IEnumerable<DayOfWeek> WeekendDays
        {
            get
            {
                yield return DayOfWeek.Saturday;
                yield return DayOfWeek.Sunday;
            }
        }

        #region Singleton

        private static volatile IDateTimeProvider instance;

        private static object syncRoot = new object();

        private DefaultDateTimeProvider() { }

        public static IDateTimeProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DefaultDateTimeProvider();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion
    }
}
