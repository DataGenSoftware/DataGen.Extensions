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
    public class StringExtensionsTests
    {
        [TestCase("Some text")]
        [TestCase("ąęśżźćńółĄĘŚŻŹŃŁÓ")]
        public void StringGetBytes_String_VerifyCorrectness(string value)
        {
            byte[] bytes = value.GetBytes();

            Assert.AreEqual(value, bytes.GetString());
        }

        [Test]
        public void StringParseEnum_ExistingEnumValueString_ReturnsEnumValue()
        {
            string value = "Sunday";

            var actual = value.ParseEnum<DayOfWeek>();

            var expected = DayOfWeek.Sunday;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StringParseEnum_NotExistingEnumValueString_ReturnsNull()
        {
            string value = "Someday";

            var actual = value.ParseEnum<DayOfWeek>();

            Assert.IsNull(actual);
        }
    }
}
