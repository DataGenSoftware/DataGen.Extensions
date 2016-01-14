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
        public void StringExtensions_GetBytes_String_VerifyCorrectness(string value)
        {
            byte[] bytes = value.GetBytes();

            Assert.AreEqual(value, bytes.GetString());
        }
    }
}
