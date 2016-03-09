using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataGen.Extensions;

namespace DataGen.Extensions.Cryptography
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

        public static byte[] AESEncrypt(this byte[] data, string password)
        {
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            KeyFactory keyFactory = new KeyFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.AES);
            return data.SymmetricAlgorithmEncrypt(symmetricAlgorithm, keyFactory.CreateKey(16, password));
        }

        public static byte[] AESDecrypt(this byte[] data, string password)
        {
            SymmetricAlgorithmFactory algorithmFactory = new SymmetricAlgorithmFactory();
            KeyFactory keyFactory = new KeyFactory();
            SymmetricAlgorithm symmetricAlgorithm = algorithmFactory.CreateSymmetricAlgorithm(SymmetricAlgorithmTypes.AES);
            return data.SymmetricAlgorithmDecrypt(symmetricAlgorithm, keyFactory.CreateKey(16, password));
        }

        
    }
}
