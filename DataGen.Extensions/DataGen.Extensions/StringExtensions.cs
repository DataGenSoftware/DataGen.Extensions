using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataGen.Extensions
{
	public static class StringExtensions
	{
		public static string EmptyIfNull(this string value)
		{
			return value ?? string.Empty;
		}

		public static string Replicate(this string value, int count)
		{
            if (value.IsNull())
            {
                return null;
            }
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
                result.Append(value);
			}
			return result.ToString();
		}

		public static string LeadWithChar(this string value, char character, int length)
		{
            if (value.IsNull())
            {
                return null;
            }
            return (character.Replicate(length - value.Length) + value);
		}

		public static string SymmetricAlgorithmEncrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, string key)
		{
			if (value.IsNotNull() && key.IsNotNull())
			{
				return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, GetKeyBytes(key));
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmEncrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, byte[] keyBytes)
		{
            if (value.IsNotNull())
            {
                byte[] valueBytes = value.GetBytes();

                var result = valueBytes.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyBytes);

                if (result.IsNotNull())
                    return result.GetString();
            }

            return null;
        }

		public static string SymmetricAlgorithmDecrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, string key)
		{
			if (value.IsNotNull() && key.IsNotNull())
			{
				return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, GetKeyBytes(key));
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmDecrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, byte[] keyBytes)
		{
			if (value.IsNotNull())
			{
				byte[] valueBytes = value.GetBytes();

                var result = valueBytes.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyBytes);

                if (result.IsNotNull())
                    return result.GetString();
			}

            return null;
		}

        public static string AESEncrypt(this string value, string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("AES");
            return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, GetKey16Bytes(key));
        }

        public static string AESDecrypt(this string value, string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("AES");
            return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, GetKey16Bytes(key));
        }

        public static string DESEncrypt(this string value, string key)
		{
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("DES");
            return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, GetKey8Bytes(key));
		}

		public static string DESDecrypt(this string value, string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("DES");
            return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, GetKey8Bytes(key));
        }

        public static string RC2Encrypt(this string value, string key)
		{
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("RC2");
            return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, key);
		}

		public static string RC2Decrypt(this string value, string key)
		{
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("RC2");
            return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, key);
		}

		public static string TripleDESEncrypt(this string value, string key)
		{
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("3DES");
            return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, key);
		}

		public static string TripleDESDecrypt(this string value, string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = MakeSymmetricAlgorithm("3DES");
            return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, key);
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

        public static byte[] GetBytes(this string value)
        {
            return System.Text.Encoding.Default.GetBytes(value);
        }

        public static Nullable<TEnum> ParseEnum<TEnum>(this string value)
            where TEnum : struct
        {
            return EnumExtensions.TryParse<TEnum>(value);
        }
	}
}
