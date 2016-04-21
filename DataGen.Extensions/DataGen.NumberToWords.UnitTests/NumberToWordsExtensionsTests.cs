using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.NumberToWords.UnitTests
{
    [TestFixture]
    public class NumberToWordsExtensionsTests
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
    }
}
