using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;
using System.Security.Cryptography;

namespace DataGen.Extensions.Tests
{
    [TestFixture]
    public class ByteExtensionsTests
    {
        [Test]
        public void ByteExtensions_HashAlgorithmComputeHash_Null_ReturnsNull()
        {
            byte[] value = null;

            byte[] actual = value.HashAlgorithmComputeHash(MD5.Create());

            Assert.IsNull(actual);
        }

        [Test]
        public void ByteExtensions_HashAlgorithmComputeHash_Bytes_ReturnsNotNull()
        {
            byte[] value = "Some text".GetBytes();

            byte[] actual = value.HashAlgorithmComputeHash(MD5.Create());

            Assert.IsNotNull(actual);
        }

        [Test]
        [Ignore]
        public void ByteExtensions_HashAlgorithmComputeHash_Bytes_ReturnsExpectedHash()
        {
            byte[] value = "Some text".GetBytes();

            byte[] actual = value.HashAlgorithmComputeHash(MD5.Create());

            byte[] expected = {  };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ByteExtensions_HashAlgorithmVerifyHash_NullValueHashFromNullValue_ReturnsFalse()
        {
            byte[] value = null;
            byte[] hash = ((byte[])null).HashAlgorithmComputeHash(MD5.Create());

            bool actual = value.HashAlgorithmVerifyHash(hash, MD5.Create());

            Assert.IsFalse(actual);
        }

        [Test]
        public void ByteExtensions_HashAlgorithmVerifyHash_BytesHashFromSameBytes_ReturnsTrue()
        {
            byte[] value = "Some text".GetBytes();
            byte[] hash = value.HashAlgorithmComputeHash(MD5.Create());

            bool actual = value.HashAlgorithmVerifyHash(hash, MD5.Create());

            Assert.IsTrue(actual);
        }

        [Test]
        public void ByteExtensions_HashAlgorithmVerifyHash_BytesHashFromDifferentBytes_ReturnsFalse()
        {
            byte[] value = "Some text".GetBytes();
            byte[] hash = "Different text".GetBytes().HashAlgorithmComputeHash(MD5.Create());

            bool actual = value.HashAlgorithmVerifyHash(hash, MD5.Create());

            Assert.IsFalse(actual);
        }
    }
}
