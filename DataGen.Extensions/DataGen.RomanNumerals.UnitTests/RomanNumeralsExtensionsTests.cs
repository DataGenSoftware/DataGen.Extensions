using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.RomanNumerals.UnitTests
{
    [TestFixture]
    public class RomanNumeralsExtensionsTests
    {
        [TestCase("IX", 9)]
        [TestCase("MCMXCIV", 1994)]
        [TestCase("", 0)]
        public void StringParseRomans_Romans_ReturnsNumber(string value, int expected)
        {
            var actual = value.ParseRomans();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Q", 0)]
        public void StringParseRomans_InvalidRoman_ThrowsArgumentException(string value, int expected)
        {
            Assert.Throws<ArgumentException>(() => value.ParseRomans());
        }

        [TestCase(0, "")]
        [TestCase(1998, "MCMXCVIII")]
        [TestCase(2015, "MMXV")]
        [TestCase(2016, "MMXVI")]
        public void ToRomans_Number_ReturnRomanNumber(int value, string expected)
        {
            Assert.AreEqual(expected, value.ToRomans());
        }
    }
}
