using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Common
{
	public class Singleton<T>
		where T : new()
	{
		private static readonly T instance = new T();

		static Singleton() { }

		public static T Instance
		{
			get
			{
				return instance;
			}
		}
	}
}
