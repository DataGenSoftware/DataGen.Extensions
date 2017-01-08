using DataGen.Extensions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Helpers
{
    public static class TimeSpanHelper
    {
        public static TimeSpan GetTimeSpanInterval(TimeInterval timeInterval)
        {
            switch (timeInterval)
            {
                case TimeInterval.Second:
                    return new TimeSpan(0, 0, 1);
                case TimeInterval.Minute:
                    return new TimeSpan(0, 1, 0);
                case TimeInterval.Hour:
                    return new TimeSpan(1, 0, 0);
                case TimeInterval.Day:
                    return new TimeSpan(1, 0, 0, 0);
                default:
                    return new TimeSpan();
            }
        }
    }
}
