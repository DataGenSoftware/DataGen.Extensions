using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
	public static class EnumExtensions
	{
		public static bool TryParse<TEnum>(string value, TEnum defaultValue, out TEnum result)
            where TEnum : struct
        {
            var enumValue = TryParse<TEnum>(value);
            if (enumValue.HasValue)
            {
                result = enumValue.Value;
                return true;
            }
			else
			{
                result = defaultValue;
                return false;
            }
		}

        public static Nullable<TEnum> TryParse<TEnum>(string value) 
            where TEnum : struct
		{
			if (value == null || !Enum.IsDefined(typeof(TEnum), value))
			{
				return null;
			}
			else
			{
				return (Nullable<TEnum>)Enum.Parse(typeof(TEnum), value);
			}
		}
    }
}
