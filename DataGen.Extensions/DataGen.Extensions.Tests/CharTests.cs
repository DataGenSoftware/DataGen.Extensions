using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Tests
{
    [TestClass]
    public class CharTests
    {
        [TestMethod]
        public void ReplicateTest()
        {
            string actual;
            string expected;

            actual = ('7').Replicate(7);
            expected = "7777777";
            Assert.AreEqual(expected, actual);

            actual = ('1').Replicate(2);
            expected = "1111";
            Assert.AreEqual(expected, actual);
        }
    }
}
