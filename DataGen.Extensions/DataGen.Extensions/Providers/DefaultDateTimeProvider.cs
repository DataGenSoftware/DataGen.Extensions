using DataGen.Extensions.Contracts;
using System;

namespace DataGen.Extensions.Providers
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }

        }

        public DateTime Today
        {
            get
            {
                return DateTime.Today;
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
