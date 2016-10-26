using DataGen.Extensions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Providers
{
    public static class DateTimeProvider
    {
        public static IDateTimeProvider Current { get; set; }

        static DateTimeProvider()
        {
            Current = DefaultDateTimeProvider.Instance;
        }
    }
}
