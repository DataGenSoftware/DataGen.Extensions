using DataGen.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Cryptography
{
    public class KeyFactory
    {
        public byte[] CreateKey(int length, string seed)
        {
            return seed.IsNotNull() ? seed.GetBytes().MD5ComputeHash().Take(length).ToArray() : null;
        }

        public byte[] CreateKey(string seed)
        {
            return seed.IsNotNull() ? seed.GetBytes().MD5ComputeHash() : null;
        }
    }
}
