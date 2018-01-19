using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;
using DataGen.Extensions.Enums;

namespace DataGen.Extentions.UnitTests
{
    [TestFixture]
    public class GenericExtensionsTests
    {
        [Test]
        public void GenericIsNull_Null_ReturnsTrue()
        {
            int? value = null;

            bool actual = value.IsNull();

            Assert.IsTrue(actual);
        }

        [Test]
        public void GenericIsNull_Instance_ReturnsFalse()
        {
            int? value = 7;

            bool actual = value.IsNull();

            Assert.IsFalse(actual);
        }

        [Test]
        public void GenericIsNotNull_Null_ReturnsFalse()
        {
            int? value = null;

            bool actual = value.IsNotNull();

            Assert.IsFalse(actual);
        }

        [Test]
        public void GenericIsNotNull_Instance_ReturnsTrue()
        {
            int? value = 7;

            bool actual = value.IsNotNull();

            Assert.IsTrue(actual);
        }

        [Test]
        public void GenericYield_Value_ReturnsIEnumerableWithOneElement()
        {
            int value = 7;

            var actual = value.Yield();

            Assert.NotNull(actual);
            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<IEnumerable<int>>(actual);
        }

		[TestCase(TimeInterval.Second, "Second")]
		[TestCase(TimeInterval.Minute, "Minute")]
		[TestCase(TimeInterval.Hour, "Hour")]
		[TestCase(TimeInterval.Day, "Day")]
		public void GenericExtensions_GetDescription_TimeIntervalEnumValue_ReturnsDescriptionOfTheEnumValue(TimeInterval timeIntervalEnumValue, string timeIntervalEnumValueDescription)
		{
			var actual = timeIntervalEnumValue.GetDescription();

			var expected = timeIntervalEnumValueDescription;
			Assert.AreEqual(expected, actual);

		}
    }
}
