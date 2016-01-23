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
	}
}
