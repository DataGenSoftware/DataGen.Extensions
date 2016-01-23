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
				return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, key.GetBytes());
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmEncrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, byte[] keyBytes)
		{
			if (value.IsNotNull() && keyBytes.IsNotNull())
			{
				byte[] valueBytes = value.GetBytes();

				symmetricAlgorithm.Key = keyBytes;

				ICryptoTransform CryptoTransform = symmetricAlgorithm.CreateEncryptor();
				byte[] result = CryptoTransform.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
				symmetricAlgorithm.Clear();

				return Convert.ToBase64String(result, 0, result.Length);
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmDecrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, string key)
		{
			if (value.IsNotNull() && key.IsNotNull())
			{
				return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, key.GetBytes());
			}
			else
				return null;
		}

		public static string SymmetricAlgorithmDecrypt(this string value, SymmetricAlgorithm symmetricAlgorithm, byte[] keyBytes)
		{
			if (value.IsNotNull() && keyBytes.IsNotNull())
			{
				byte[] valueBytes = value.GetBytes();

				symmetricAlgorithm.Key = keyBytes;

				ICryptoTransform CryptoTransform = symmetricAlgorithm.CreateDecryptor();
				byte[] result = CryptoTransform.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
				symmetricAlgorithm.Clear();

				return UTF8Encoding.UTF8.GetString(result);
			}
			else
				return null;
		}

		public static string DESEncrypt(this string value, string key)
		{
			SymmetricAlgorithm symmetricAlgorithm = new DESCryptoServiceProvider();
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			byte[] keyBytes = key.IsNotNull() ? key.GetBytes().MD5ComputeHash().Take(8).ToArray() : null;
			return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyBytes);
		}

		public static string DESDecrypt(this string value, string key)
		{
			SymmetricAlgorithm symmetricAlgorithm = new DESCryptoServiceProvider();
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			byte[] keyBytes = key.IsNotNull() ? key.GetBytes().MD5ComputeHash().Take(8).ToArray() : null;
			return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyBytes);
		}

		public static string RC2Encrypt(this string value, string key)
		{
			SymmetricAlgorithm symmetricAlgorithm = new RC2CryptoServiceProvider();
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			byte[] keyBytes = key.IsNotNull() ? key.GetBytes().MD5ComputeHash() : null;
			return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyBytes);
		}

		public static string RC2Decrypt(this string value, string key)
		{
			SymmetricAlgorithm symmetricAlgorithm = new RC2CryptoServiceProvider();
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			byte[] keyBytes = key.IsNotNull() ? key.GetBytes().MD5ComputeHash() : null;
			return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyBytes);
		}

		public static string TripleDESEncrypt(this string value, string key)
		{
			SymmetricAlgorithm symmetricAlgorithm = new TripleDESCryptoServiceProvider();
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			byte[] keyBytes = key.IsNotNull() ? key.GetBytes().MD5ComputeHash() : null;
			return value.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyBytes);
		}

		public static string TripleDESDecrypt(this string value, string key)
		{
			SymmetricAlgorithm symmetricAlgorithm = new TripleDESCryptoServiceProvider();
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			byte[] keyBytes = key.IsNotNull() ? key.GetBytes().MD5ComputeHash() : null;
			return value.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyBytes);
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
            return System.Text.Encoding.Unicode.GetBytes(value);
        }

        public static Nullable<TEnum> ParseEnum<TEnum>(this string value)
            where TEnum : struct
        {
            return EnumExtensions.TryParse<TEnum>(value);
        }
	}
}
