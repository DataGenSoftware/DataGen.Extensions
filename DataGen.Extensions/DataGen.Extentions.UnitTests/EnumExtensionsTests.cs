using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;

namespace DataGen.Extentions.UnitTests
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        [Test]
        public void EnumTryParse_ExistingEnumValueString_ReturnsTrue()
        {
            var value = "Sunday";
            var result = new DayOfWeek();
            var defaultValue = DayOfWeek.Friday;

            var actual = EnumExtensions.TryParse<DayOfWeek>(value, defaultValue, out result);

            Assert.IsTrue(actual);
        }

        [Test]
        public void EnumTryParse_NotExistingEnumValueString_ReturnsFalse()
        {
            var value = "Someday";
            var result = new DayOfWeek();
            var defaultValue = DayOfWeek.Friday;

            var actual = EnumExtensions.TryParse<DayOfWeek>(value, defaultValue, out result);

            Assert.IsFalse(actual);
        }

        [Test]
        public void EnumTryParse_NotExistingEnumValueString_ReturnsDefaultValue()
        {
            var value = "Someday";
            var result = new DayOfWeek();
            var defaultValue = DayOfWeek.Friday;

            EnumExtensions.TryParse<DayOfWeek>(value, defaultValue, out result);
            var actual = result;

            var expected = DayOfWeek.Friday;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnumTryParse_Null_ReturnsDefaultValue()
        {
            string value = null;
            var result = new DayOfWeek();
            var defaultValue = DayOfWeek.Friday;

            EnumExtensions.TryParse<DayOfWeek>(value, defaultValue, out result);
            var actual = result;

            var expected = DayOfWeek.Friday;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnumTryParse_ExistingEnumValueString_ReturnsEnumValue()
        {
            var value = "Sunday";
            
            var actual = EnumExtensions.TryParse<DayOfWeek>(value);

            var expected = DayOfWeek.Sunday;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnumTryParse_NotExistingEnumValueString_ReturnsNull()
        {
            var value = "Someday";

            var actual = EnumExtensions.TryParse<DayOfWeek>(value);

            Assert.IsNull(actual);
        }

        [Test]
        public void EnumTryParse_Null_ReturnsNull()
        {
            string value = null;

            var actual = EnumExtensions.TryParse<DayOfWeek>(value);

            Assert.IsNull(actual);
        }
    }
}
