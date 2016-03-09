using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataGen.Extensions
{
	public static class ByteExtensions
	{
		public static byte[] ComputeHash(this byte[] value, HashAlgorithm hashAlgorithm)
		{
			if (value.IsNotNull() == true)
			{
				return hashAlgorithm.ComputeHash(value);
			}
			else
				return null;
		}

		public static bool VerifyHash(this byte[] value, byte[] hash, HashAlgorithm hashAlgorithm)
		{
            byte[] hashToCompare = value.ComputeHash(hashAlgorithm);

            if (hash == null || hashToCompare == null)
            {
                return false;
            }

            if (hash.Length != hashToCompare.Length)
            {
                return false;
            }

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] !=hashToCompare[i])
                {
                    return false;
                }
            }

            return true;
		}

		public static byte[] MD5ComputeHash(this byte[] value)
		{
			return value.ComputeHash(MD5.Create());
		}

		public static bool MD5VerifyHash(this byte[] value, byte[] hash)
		{
			return value.VerifyHash(hash, MD5.Create());
		}

        public static string GetString(this byte[] value)
        {
            return System.Text.Encoding.Default.GetString(value);
        }

        public static byte[] SymmetricAlgorithmEncrypt(this byte[] value, SymmetricAlgorithm symmetricAlgorithm, byte[] key)
        {
            if (value.IsNotNull() && key.IsNotNull())
            {
                symmetricAlgorithm.Key = key;

                ICryptoTransform CryptoTransform = symmetricAlgorithm.CreateEncryptor();
                byte[] result = CryptoTransform.TransformFinalBlock(value, 0, value.Length);
                symmetricAlgorithm.Clear();

                return result;
            }
            else
                return null;
        }

        public static byte[] SymmetricAlgorithmDecrypt(this byte[] value, SymmetricAlgorithm symmetricAlgorithm, byte[] key)
        {
            if (value.IsNotNull() && key.IsNotNull())
            {
                symmetricAlgorithm.Key = key;

                ICryptoTransform CryptoTransform = symmetricAlgorithm.CreateDecryptor();
                byte[] result = CryptoTransform.TransformFinalBlock(value, 0, value.Length);
                symmetricAlgorithm.Clear();

                return result;
            }
            else
                return null;
        }

        public static byte[] AESEncrypt(this byte[] data, string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("AES");
            return data.SymmetricAlgorithmEncrypt(symmetricAlgorithm, GetKey16Bytes(key));
        }

        public static byte[] AESDecrypt(this byte[] data, string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("AES");
            return data.SymmetricAlgorithmDecrypt(symmetricAlgorithm, GetKey16Bytes(key));
        }

        public static SymmetricAlgorithm MakeSymmetricAlgorithm(string algorithmName)
        {
            SymmetricAlgorithm symmetricAlgorithm = null;

            switch (algorithmName)
            {
                case "AES":
                    symmetricAlgorithm = new AesCryptoServiceProvider();
                    break;
                case "DES":
                    symmetricAlgorithm = new DESCryptoServiceProvider();
                    break;
                case "RC2":
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    break;
                case "3DES":
                    symmetricAlgorithm = new TripleDESCryptoServiceProvider();
                    break;
            }

            if (symmetricAlgorithm.IsNotNull())
            {
                symmetricAlgorithm.Mode = CipherMode.ECB;
                symmetricAlgorithm.Padding = PaddingMode.PKCS7;
            }

            return symmetricAlgorithm;
        }

        private static byte[] GetKeyBytes(string key)
        {
            return key.IsNotNull() ? key.GetBytes().MD5ComputeHash() : null;
        }

        private static byte[] GetKey8Bytes(string key)
        {
            return key.IsNotNull() ? key.GetBytes().MD5ComputeHash().Take(8).ToArray() : null;
        }

        private static byte[] GetKey16Bytes(string key)
        {
            return key.IsNotNull() ? key.GetBytes().MD5ComputeHash().Take(16).ToArray() : null;
        }

        private static byte[] GetKey32Bytes(string key)
        {
            return key.IsNotNull() ? key.GetBytes().MD5ComputeHash().Take(32).ToArray() : null;
        }
    }
}
