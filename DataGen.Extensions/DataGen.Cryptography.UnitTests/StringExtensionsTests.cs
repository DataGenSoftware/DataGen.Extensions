using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Cryptography.UnitTests
{
    [TestFixture]
    public class StringExtensionsTests
    {

        #region AES

        [TestCase("Some text to encrypt", "key")]
        [TestCase("", "key")]
        public void StringAESEncryptDecrypt_Text_Verify(string value, string key)
        {
            var actual = value.AESEncrypt(key).AESDecrypt(key);

            var expected = value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StringAESEncrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.AESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringAESEncrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to encrypt";
            string key = null;

            var actual = value.AESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringAESDecrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.AESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringAESDecrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to decrypt";
            string key = null;

            var actual = value.AESEncrypt(key);

            Assert.IsNull(actual);
        }

        #endregion

        #region DES

        [TestCase("Some text to encrypt", "key")]
        [TestCase("", "key")]
        public void StringDESEncryptDecrypt_Text_Verify(string value, string key)
        {
            var actual = value.DESEncrypt(key).DESDecrypt(key);

            var expected = value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StringDESEncrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.DESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringDESEncrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to encrypt";
            string key = null;

            var actual = value.DESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringDESDecrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.DESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringDESDecrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to decrypt";
            string key = null;

            var actual = value.DESEncrypt(key);

            Assert.IsNull(actual);
        }

        #endregion

        #region RC2

        [TestCase("Some text to encrypt", "key")]
        [TestCase("", "key")]
        public void StringRC2EncryptDecrypt_Text_Verify(string value, string key)
        {
            var actual = value.RC2Encrypt(key).RC2Decrypt(key);

            var expected = value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StringRC2Encrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.RC2Encrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringRC2Encrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to encrypt";
            string key = null;

            var actual = value.RC2Encrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringRC2Decrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.RC2Encrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringRC2Decrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to decrypt";
            string key = null;

            var actual = value.RC2Encrypt(key);

            Assert.IsNull(actual);
        }

        #endregion

        #region TripleDES

        [TestCase("Some text to encrypt", "key")]
        [TestCase("", "key")]
        public void StringTripleDESEncryptDecrypt_Text_Verify(string value, string key)
        {
            var actual = value.TripleDESEncrypt(key).TripleDESDecrypt(key);

            var expected = value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StringTripleDESEncrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.TripleDESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringTripleDESEncrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to encrypt";
            string key = null;

            var actual = value.TripleDESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringTripleDESDecrypt_NullText_ReturnsNull()
        {
            string value = null;
            string key = "key";

            var actual = value.TripleDESEncrypt(key);

            Assert.IsNull(actual);
        }

        [Test]
        public void StringTripleDESDecrypt_NullKey_ReturnsNull()
        {
            string value = "Some text to decrypt";
            string key = null;

            var actual = value.TripleDESEncrypt(key);

            Assert.IsNull(actual);
        }

        #endregion

        #region MD5

        [TestCase("Some text to encrypt")]
        [TestCase("")]
        public void StringMD5ComputeHashVerifyHash_TextVerify_Verify(string value)
        {
            var hash = value.MD5ComputeHash();

            var actual = value.MD5VerifyHash(hash);

            Assert.IsTrue(actual);
        }

        [Test]
        public void StringMD5ComputeHash_NullText_ReturnsNull()
        {
            string value = null;

            var actual = value.MD5ComputeHash();

            Assert.IsNull(actual);
        }

        [Test]
        public void StringMD5VerifyHash_NullHash_ReturnsFalse()
        {
            string value = "Some text to encrypt";
            string hash = null;

            var actual = value.MD5VerifyHash(hash);

            Assert.IsFalse(actual);
        }

        [Test]
        public void StringMD5VerifyHash_NullText_ReturnsFalse()
        {
            string value = null;
            string hash = "hash";

            var actual = value.MD5VerifyHash(hash);

            Assert.IsFalse(actual);
        }

        #endregion

        #region SHA1

        [TestCase("Some text to encrypt")]
        [TestCase("")]
        public void StringSHA1ComputeHashVerifyHash_TextVerify_Verify(string value)
        {
            var hash = value.SHA1ComputeHash();

            var actual = value.SHA1VerifyHash(hash);

            Assert.IsTrue(actual);
        }

        [Test]
        public void StringSHA1ComputeHash_NullText_ReturnsNull()
        {
            string value = null;

            var actual = value.SHA1ComputeHash();

            Assert.IsNull(actual);
        }

        [Test]
        public void StringSHA1VerifyHash_NullHash_ReturnsFalse()
        {
            string value = "Some text to encrypt";
            string hash = null;

            var actual = value.MD5VerifyHash(hash);

            Assert.IsFalse(actual);
        }

        [Test]
        public void StringSHA1VerifyHash_NullText_ReturnsFalse()
        {
            string value = null;
            string hash = "hash";

            var actual = value.MD5VerifyHash(hash);

            Assert.IsFalse(actual);
        }

        #endregion
    }
}
