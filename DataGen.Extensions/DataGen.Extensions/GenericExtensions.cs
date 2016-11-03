using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNull<T>(this Nullable<T> objectInstance) 
            where T :struct
        {
            return objectInstance == null;
        }

        public static bool IsNull<T>(this T objectInstance) 
            where T : class
        {
            return objectInstance == null;
        }

        public static bool IsNotNull<T>(this Nullable<T> objectInstance) 
            where T : struct
        {
            return !objectInstance.IsNull();
        }

        public static bool IsNotNull<T>(this T objectInstance)
            where T : class
        {
            return !objectInstance.IsNull();
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
    }
}
