using DataGen.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Core
{
	public class Settings : Singleton<Settings>, ISeetings
	{
		public DayOfWeek FirstDayOfWeek { get; set; }

		public List<DayOfWeek> WeekendDays { get; set; }

		public Settings()
			: base()
		{
			this.FirstDayOfWeek = DayOfWeek.Monday;
			this.WeekendDays = new List<DayOfWeek>()
			{
				DayOfWeek.Saturday,
				DayOfWeek.Sunday,
			};
		}

		public void SettingSet(string settingName)
		{

		}
	}
}
