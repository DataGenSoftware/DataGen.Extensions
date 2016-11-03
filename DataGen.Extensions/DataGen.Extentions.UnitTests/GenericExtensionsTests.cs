﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;

namespace DataGen.Extentions.UnitTests
{
    [TestFixture]
    public class GenericExtensionsTests
    {
        [Test]
        public void GenericIsNull_Null_ReturnsTrue()
        {
            int? objectInstance = null;

            bool actual = objectInstance.IsNull();

            Assert.IsTrue(actual);
        }

        [Test]
        public void GenericIsNull_Instance_ReturnsFalse()
        {
            int? objectInstance = 7;

            bool actual = objectInstance.IsNull();

            Assert.IsFalse(actual);
        }

        [Test]
        public void GenericIsNotNull_Null_ReturnsFalse()
        {
            int? objectInstance = null;

            bool actual = objectInstance.IsNotNull();

            Assert.IsFalse(actual);
        }

        [Test]
        public void GenericIsNotNull_Instance_ReturnsTrue()
        {
            int? objectInstance = 7;

            bool actual = objectInstance.IsNotNull();

            Assert.IsTrue(actual);
        }
    }
}
