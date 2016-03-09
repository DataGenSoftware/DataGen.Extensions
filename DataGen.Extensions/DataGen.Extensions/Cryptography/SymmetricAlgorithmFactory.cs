using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Cryptography
{
    public class SymmetricAlgorithmFactory
    {
        public SymmetricAlgorithm CreateSymmetricAlgorithm(SymmetricAlgorithmTypes algorithmType)
        {
            SymmetricAlgorithm symmetricAlgorithm = null;

            switch (algorithmType)
            {
                case SymmetricAlgorithmTypes.AES:
                    symmetricAlgorithm = new AesCryptoServiceProvider();
                    break;
                case SymmetricAlgorithmTypes.DES:
                    symmetricAlgorithm = new DESCryptoServiceProvider();
                    break;
                case SymmetricAlgorithmTypes.RC2:
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    break;
                case SymmetricAlgorithmTypes.TripleDES:
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
    }
}
