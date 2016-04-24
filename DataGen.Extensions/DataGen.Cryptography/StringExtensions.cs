using DataGen.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataGen.Cryptography
{

    public static class StringExtensions
	{
		public static string SymmetricAlgorithmEncrypt(this string text, SymmetricAlgorithm symmetricAlgorithm, string password)
		{
			if (text.IsNotNull() && password.IsNotNull())
			{
                KeyFactory keyFactory = new KeyFactory();

                return text.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyFactory.CreateKey(password));
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmEncrypt(this string text, SymmetricAlgorithm symmetricAlgorithm, byte[] key)
		{
            if (text.IsNotNull())
            {
                byte[] valueBytes = text.GetBytes();

                var result = valueBytes.SymmetricAlgorithmEncrypt(symmetricAlgorithm, key);

                if (result.IsNotNull())
                    return result.GetString();
            }

            return null;
        }

		public static string SymmetricAlgorithmDecrypt(this string text, SymmetricAlgorithm symmetricAlgorithm, string password)
		{
			if (text.IsNotNull() && password.IsNotNull())
			{
                KeyFactory keyFactory = new KeyFactory();
                return text.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyFactory.CreateKey(password));
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmDecrypt(this string text, SymmetricAlgorithm symmetricAlgorithm, byte[] key)
		{
			if (text.IsNotNull())
			{
				byte[] valueBytes = text.GetBytes();

                var result = valueBytes.SymmetricAlgorithmDecrypt(symmetricAlgorithm, key);

                if (result.IsNotNull())
                    return result.GetString();
			}

            return null;
		}

        public static string AESEncrypt(this string text, string password)
        {
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            KeyFactory keyFactory = new KeyFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.AES);
            return text.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyFactory.CreateKey(16, password));
        }

        public static string AESDecrypt(this string text, string password)
        {
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            KeyFactory keyFactory = new KeyFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.AES);
            return text.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyFactory.CreateKey(16, password));
        }

        public static string DESEncrypt(this string text, string password)
		{
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            KeyFactory keyFactory = new KeyFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.DES);
            return text.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyFactory.CreateKey(8, password));
        }

		public static string DESDecrypt(this string text, string password)
        {
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            KeyFactory keyFactory = new KeyFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.DES);
            return text.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyFactory.CreateKey(8, password));
        }

        public static string RC2Encrypt(this string text, string password)
		{
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.RC2);
            return text.SymmetricAlgorithmEncrypt(symmetricAlgorithm, password);
        }

		public static string RC2Decrypt(this string text, string password)
		{
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.RC2);
            return text.SymmetricAlgorithmDecrypt(symmetricAlgorithm, password);
        }

		public static string TripleDESEncrypt(this string text, string password)
		{
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.TripleDES);
            return text.SymmetricAlgorithmEncrypt(symmetricAlgorithm, password);
        }

		public static string TripleDESDecrypt(this string text, string password)
        {
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.TripleDES);
            return text.SymmetricAlgorithmDecrypt(symmetricAlgorithm, password);
        }
        
        public static string HashAlgorithmComputeHash(this string value, HashAlgorithm hashAlgorithm)
		{
			if (value.IsNotNull() == true)
			{
				byte[] hash = hashAlgorithm.ComputeHash(value.GetBytes());
				StringBuilder result = new StringBuilder();
				for (int i = 0; i < hash.Length; i++)
				{
					result.Append(hash[i].ToString("X2"));
				}
				return result.ToString();
			}
			else
				return null;
		}

		public static bool HashAlgorithmVerifyHash(this string value, string hash, HashAlgorithm hashAlgorithm)
		{
			return StringComparer.OrdinalIgnoreCase.Compare(value.HashAlgorithmComputeHash(hashAlgorithm), hash) == 0;
		}

		public static string KeyedHashAlgorithmComputeHash(this string value)
		{
			return value.HashAlgorithmComputeHash(KeyedHashAlgorithm.Create());
		}

		public static bool KeyedHashAlgorithmVerifyHash(this string value, string hash)
		{
			return value.HashAlgorithmVerifyHash(hash, KeyedHashAlgorithm.Create());
		}

		public static string MD5ComputeHash(this string value)
		{
			return value.HashAlgorithmComputeHash(MD5.Create());
		}

		public static bool MD5VerifyHash(this string value, string hash)
		{
			return value.HashAlgorithmVerifyHash(hash, MD5.Create());
		}

		public static string SHA1ComputeHash(this string value)
		{
			return value.HashAlgorithmComputeHash(SHA1.Create());
		}

		public static bool SHA1VerifyHash(this string value, string hash)
		{
			return value.HashAlgorithmVerifyHash(hash, SHA1.Create());
		}

		public static string SHA256ComputeHash(this string value)
		{
			return value.HashAlgorithmComputeHash(SHA256.Create());
		}

		public static bool SHA256VerifyHash(this string value, string hash)
		{
			return value.HashAlgorithmVerifyHash(hash, SHA256.Create());
		}

		public static string SHA384ComputeHash(this string value)
		{
			return value.HashAlgorithmComputeHash(SHA384.Create());
		}

		public static bool SHA384VerifyHash(this string value, string hash)
		{
			return value.HashAlgorithmVerifyHash(hash, SHA384.Create());
		}

		public static string SHA512ComputeHash(this string value)
		{
			return value.HashAlgorithmComputeHash(SHA512.Create());
		}

		public static bool SHA512VerifyHash(this string value, string hash)
		{
			return value.HashAlgorithmVerifyHash(hash, SHA512.Create());
		}
	}
}
