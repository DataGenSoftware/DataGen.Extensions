using System;
using System.Collections.Generic;

namespace DataGen.Extensions.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }

        DateTime Today { get; }

        DayOfWeek FirstDayOfWeek { get; }

        IEnumerable<DayOfWeek> WeekendDays { get; }
    }
}
