using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataGen.Extensions
{
	public static class StringExtensions
	{
		public static string EmptyIfNull(this string value)
		{
			return value ?? string.Empty;
		}

		public static string Replicate(this string value, int count)
		{
            if (value.IsNull())
            {
                return null;
            }
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
                result.Append(value);
			}
			return result.ToString();
		}

        public static string LeadWithChar(this string value, char character, int length)
        {
            if (value.IsNull())
            {
                return null;
            }
            return (character.Replicate(length - value.Length) + value);
        }

        public static byte[] GetBytes(this string value)
        {
            return System.Text.Encoding.Default.GetBytes(value);
        }

        public static Nullable<TEnum> ParseEnum<TEnum>(this string value)
            where TEnum : struct
        {
            return EnumExtensions.TryParse<TEnum>(value);
        }
    }
}
