using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
	public static class ObjectExtensions
	{
		public static bool IsNull(this object objectInstance)
		{
			return objectInstance == null;
		}

		public static bool IsNotNull(this object objectInstance)
		{
			return !objectInstance.IsNull();
		}
	}
}
