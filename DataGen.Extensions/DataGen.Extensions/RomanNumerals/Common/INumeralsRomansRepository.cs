using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.RomanNumerals
{
    public interface INumeralsRomansRepository
    {
        IDictionary<int, string> Dictionary { get; set; }

        string Get(int value);
    }
}
