using DataGen.Extensions;
using DataGen.Extensions.RomanNumerals;
using DataGen.Extensions.NumberToWords;
using DataGen.Extensions.NumberToWords.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extentions.UnitTests
{
    [TestFixture]
    public class NumberExtensionsTests
    {
        [TestCase(1, "jeden", "pl-PL")]
        [TestCase(100, "sto", "pl-PL")]
        [TestCase(101, "sto jeden", "pl-PL")]
        [TestCase(1234, "jeden tysiąc dwieście trzydzieści cztery", "pl-PL")]
        [TestCase(12345, "dwanaście tysięcy trzysta czterdzieści pięć", "pl-PL")]
        [TestCase(100100, "sto tysięcy sto", "pl-PL")]
        [TestCase(1234567, "jeden milion dwieście trzydzieści cztery tysiące pięćset sześćdziesiąt siedem", "pl-PL")]
        [TestCase(123456789, "sto dwadzieścia trzy miliony czterysta pięćdziesiąt sześć tysięcy siedemset osiemdziesiąt dziewięć", "pl-PL")]

        [TestCase(0, "", "en-US")]
        [TestCase(1, "one", "en-US")]
        [TestCase(100, "one hundred", "en-US")]
        [TestCase(101, "one hundred one", "en-US")]
        [TestCase(1234, "one thousand two hundred thirty four", "en-US")]
        [TestCase(12345, "twelve thousand three hundred fourty five", "en-US")]
        [TestCase(100100, "one hundred thousand one hundred", "en-US")]
        [TestCase(1234567, "one milion two hundred thirty four thousand five hundred sixty seven", "en-US")]
        [TestCase(123456789, "one hundred twenty three milion four hundred fifty six thousand seven hundred eighty nine", "en-US")]

        public void InWords_Number_ReturnsWords(int value, string expected, string cultureName)
        {
            var actual = value.ToWords(cultureName);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(3000000000)]
        public void ToRomans_NumberOutOfRange_ThrowsArgumentOutOfRangeException(long value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.ToWords("en-US"));

            StringAssert.Contains("value", ex.ParamName);
        }

        [Test]
        public void ToWords_InvalidCultureName_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => 1.ToWords("xx-XX"));

            StringAssert.Contains("Invalid argument", ex.Message);
            StringAssert.Contains("cultureName", ex.ParamName);
        }

        [TestCase(0, "")]
        [TestCase(1998, "MCMXCVIII")]
        [TestCase(2015, "MMXV")]
        [TestCase(2016, "MMXVI")]
        public void ToRomans_Number_ReturnRomanNumber(int value, string expected)
        {
            Assert.AreEqual(expected, value.ToRomans());
        }

        [TestCase(3, 2, 5)]
        [TestCase(7.5, 5.1, 9.2)]
        [TestCase(4, 4, 4)]
        public void IsInRange_NumberInRange_ReturnsTrue<T>(T value, T begin, T end)
            where T : IComparable
        {
            var actual = value.IsInRange(begin, end);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 5)]
        [TestCase(10.2, 5.0, 9.0)]
        public void IsInRange_NumberOutOfRange_ReturnsFalse<T>(T value, T begin, T end)
            where T : IComparable
        {
            var x = 10.3M;
            var actual = value.IsInRange(begin, end);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 5, 2)]
        public void IsInRange_IncorrectRange_ThrowsArgumentException<T>(T value, T begin, T end)
            where T : IComparable
        {
            var ex = Assert.Throws<ArgumentException>(() => value.IsInRange(begin, end));

            StringAssert.Contains("The begining value of the range cannot be greater that the end value of the range", ex.Message);
            StringAssert.Contains("begin", ex.ParamName);
        }
    }
}
