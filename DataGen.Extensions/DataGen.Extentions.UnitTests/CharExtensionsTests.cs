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
    public class CharExtensionsTests
    {
        [Test]
        public void CharExtensions_Replicate_ASignThreeTimes_ReturnsAAA()
        {
            char sign = 'A';
            int times = 3;

            string actual = sign.Replicate(times);

            string expected = "AAA";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CharExtensions_Replicate_ASignZeroTimes_ReturnsEmptyString()
        {
            char sign = 'A';
            int times = 0;

            string actual = sign.Replicate(times);

            string expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }
    }
}
