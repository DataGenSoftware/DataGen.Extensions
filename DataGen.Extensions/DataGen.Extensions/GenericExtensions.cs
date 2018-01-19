using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

		/// <summary>
		/// Gets the content of the description attribute
		/// </summary>
		/// <typeparam name="T">Type of the source object</typeparam>
		/// <param name="source">Instance of the source object</param>
		/// <returns>Content of the description attribute</returns>
		public static string GetDescription<T>(this T source)
		{
			FieldInfo fi = source.GetType().GetField(source.ToString());

			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0)
				return attributes[0].Description;
			else
				return source.ToString();
		}
	}
}
