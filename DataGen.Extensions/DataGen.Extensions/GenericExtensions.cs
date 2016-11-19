using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNull<T>(this Nullable<T> value) 
            where T :struct
        {
            return value == null;
        }

        public static bool IsNull<T>(this T value) 
            where T : class
        {
            return value == null;
        }

        public static bool IsNotNull<T>(this Nullable<T> value) 
            where T : struct
        {
            return !value.IsNull();
        }

        public static bool IsNotNull<T>(this T value)
            where T : class
        {
            return !value.IsNull();
        }

        public static T DefaultIfNull<T>(this Nullable<T> value, T defaultValue)
            where T : struct
        {
            return value ?? defaultValue;
        }

        public static T DefaultIfNull<T>(this T value, T defaultValue)
            where T : class
        {
            return value ?? defaultValue;
        }

        public static IEnumerable<T> Yield<T>(this T value)
        {
            return new T[] { value };
        }
    }
}
