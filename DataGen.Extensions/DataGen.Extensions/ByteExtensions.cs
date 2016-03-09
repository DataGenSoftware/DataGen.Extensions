using DataGen.Extensions.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataGen.Extensions
{
    public static class ByteExtensions
    {
        public static string GetString(this byte[] value)
        {
            return System.Text.Encoding.Default.GetString(value);
        }
    }
}
