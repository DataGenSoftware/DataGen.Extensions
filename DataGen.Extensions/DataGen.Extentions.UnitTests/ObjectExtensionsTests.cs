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
    public class ObjectExtensionsTests
    {
        [Test]
        public void ObjectIsNull_Null_ReturnsTrue()
        {
            object objectInstance = null;

            bool actual = objectInstance.IsNull();

            Assert.IsTrue(actual);
        }

        [Test]
        public void ObjectIsNull_Instance_ReturnsFalse()
        {
            object objectInstance = new object();

            bool actual = objectInstance.IsNull();

            Assert.IsFalse(actual);
        }

        [Test]
        public void ObjectIsNotNull_Null_ReturnsFalse()
        {
            object objectInstance = null;

            bool actual = objectInstance.IsNotNull();

            Assert.IsFalse(actual);
        }

        [Test]
        public void ObjectIsNotNull_Instance_ReturnsTrue()
        {
            object objectInstance = new object();

            bool actual = objectInstance.IsNotNull();

            Assert.IsTrue(actual);
        }
    }
}
