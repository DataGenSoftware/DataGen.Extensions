using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.RomanNumerals
{
    public interface IRomansNumeralsRepository
    {
        IDictionary<char, int> Dictionary { get; set; }

        int Get(char value);
    }
}
