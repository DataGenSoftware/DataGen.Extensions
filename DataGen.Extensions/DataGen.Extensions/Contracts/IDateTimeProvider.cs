using System;

namespace DataGen.Extensions.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }

        DateTime Today { get; }
    }
}
