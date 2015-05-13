using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataGenExtensions
{
	public static class ByteExtensions
	{
		public static byte[] HashAlgorithmComputeHash(this byte[] value, HashAlgorithm hashAlgorithm)
		{
			if (value.IsNotNull() == true)
			{
				return hashAlgorithm.ComputeHash(value);
			}
			else
				return null;
		}

		public static bool HashAlgorithmVerifyHash(this byte[] value, byte[] hash, HashAlgorithm hashAlgorithm)
		{
			return value.HashAlgorithmComputeHash(hashAlgorithm).Equals(hash);
		}

		public static byte[] MD5ComputeHash(this byte[] value)
		{
			return value.HashAlgorithmComputeHash(MD5.Create());
		}

		public static bool MD5VerifyHash(this byte[] value, byte[] hash)
		{
			return value.HashAlgorithmVerifyHash(hash, MD5.Create());
		}
	}
}
