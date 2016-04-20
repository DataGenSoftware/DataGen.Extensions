using DataGen.Common.RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.RomanNumerals
{
    public class RomansNumeralsRepository : IRomansNumeralsRepository
    {
        public IDictionary<char, int> Dictionary { get; set; }

        public RomansNumeralsRepository()
        {
            this.Dictionary = this.GetRomanNumerals();
        }

        public virtual int Get(char value)
        {
            return this.Dictionary[value];
        }

        public virtual IDictionary<char, int> GetRomanNumerals()
        {
            return new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

        }
    }
}