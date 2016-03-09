using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;
using DataGen.Extensions.Cryptography;
using System.Security.Cryptography;

namespace DataGen.Extensions.Tests
{
    [TestFixture]
    public class ByteExtensionsTests
    {
        [Test]
        public void ByteHashAlgorithmComputeHash_Null_ReturnsNull()
        {
            byte[] value = null;

            byte[] actual = value.ComputeHash(MD5.Create());

            Assert.IsNull(actual);
        }

        [Test]
        public void ByteHashAlgorithmComputeHash_Bytes_ReturnsBytes()
        {
            byte[] value = "Some text".GetBytes();

            byte[] actual = value.ComputeHash(MD5.Create());

            Assert.IsNotNull(actual);
        }

        [Test]
        public void ByteHashAlgorithmVerifyHash_NullValueHashFromNullValue_ReturnsFalse()
        {
            byte[] value = null;
            byte[] hash = ((byte[])null).ComputeHash(MD5.Create());

            bool actual = value.VerifyHash(hash, MD5.Create());

            Assert.IsFalse(actual);
        }

        [Test]
        public void ByteHashAlgorithmVerifyHash_BytesHashFromSameBytes_ReturnsTrue()
        {
            byte[] value = "Some text".GetBytes();
            byte[] hash = value.ComputeHash(MD5.Create());

            bool actual = value.VerifyHash(hash, MD5.Create());

            Assert.IsTrue(actual);
        }

        [Test]
        public void ByteHashAlgorithmVerifyHash_BytesHashFromDifferentBytes_ReturnsFalse()
        {
            byte[] value = "Some text".GetBytes();
            byte[] hash = "Different text".GetBytes().ComputeHash(MD5.Create());

            bool actual = value.VerifyHash(hash, MD5.Create());

            Assert.IsFalse(actual);
        }

        [Test]
        public void ByteMD5ComputeHash_Null_RetutnsNull()
        {
            byte[] value = null;

            byte[] actual = value.MD5ComputeHash();

            Assert.IsNull(actual);
        }

        [Test]
        public void ByteMD5ComputeHash_Bytes_RetutnsBytes()
        {
            byte[] value = "Some text".GetBytes();

            byte[] actual = value.MD5ComputeHash();

            Assert.IsNotNull(actual);
        }

        [Test]
        public void ByteMD5ComputeHash_NullValueHashFromNullValue_ReturnsFalse()
        {
            byte[] value = null;
            byte[] hash = ((byte[])null).MD5ComputeHash();

            bool actual = value.MD5VerifyHash(hash);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ByteMD5ComputeHash_BytesHashFromSameBytes_ReturnsTrue()
        {
            byte[] value = "Some text".GetBytes();
            byte[] hash = value.MD5ComputeHash();

            bool actual = value.MD5VerifyHash(hash);

            Assert.IsTrue(actual);
        }

        [Test]
        public void ByteMD5ComputeHash_BytesHashFromDifferentBytes_ReturnsFalse()
        {
            byte[] value = "Some text".GetBytes();
            byte[] hash = "Different text".GetBytes().MD5ComputeHash();

            bool actual = value.MD5VerifyHash(hash);

            Assert.IsFalse(actual);
        }
    }
}
