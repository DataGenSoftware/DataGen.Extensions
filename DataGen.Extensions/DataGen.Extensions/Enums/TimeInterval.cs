using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Enums
{
	public enum TimeInterval
	{
		[Description("Second")]
        Second,

		[Description("Minute")]
		Minute,

		[Description("Hour")]
		Hour,

		[Description("Day")]
		Day,
    }
}
