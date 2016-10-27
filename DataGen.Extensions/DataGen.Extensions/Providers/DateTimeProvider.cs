using DataGen.Extensions.Contracts;

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
