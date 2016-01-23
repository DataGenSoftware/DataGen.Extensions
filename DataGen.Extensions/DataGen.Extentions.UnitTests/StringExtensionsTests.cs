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

        [Test]
        public void StringEmptyIfNull_Null_ReturnsEmptyString()
        {
            string value = null;

            var actual = value.EmptyIfNull();

            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Text", 3, "TextTextText")]
        [TestCase("Text", -1, "")]
        [TestCase(null, 2, null)]
        public void StringReplicate_TextCount_ReturnsReplicatedText(string value, int count, string expected)
        {
            var actual = value.Replicate(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", '0', 2, "01")]
        [TestCase("12", '0', 6, "000012")]
        [TestCase(null, '0', 3, null)]
        [TestCase("1", '0', -1, "1")]
        public void StringLeadWithChar_TextCharLenght_ReturnsTextWithLeadingChars(string value, char character, int length, string expected)
        {
            var actual = value.LeadWithChar(character, length);

            Assert.AreEqual(expected, actual);
        }
    }
}
