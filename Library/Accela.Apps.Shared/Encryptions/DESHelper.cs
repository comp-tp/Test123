﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Accela.Apps.Shared.Toolkits.Encrypt
{
    public class DESHelper
    {
        private static string keyInfo = "!@12*?'E";

        public static string Encrypt(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return string.Empty;
            }
            byte[] sourceByte = Encoding.UTF8.GetBytes(source);
            byte[] keyByte = Encoding.UTF8.GetBytes(keyInfo);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = keyByte;
            provider.IV = keyByte;

            MemoryStream stream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(sourceByte, 0, sourceByte.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return Convert.ToBase64String(stream.ToArray());
        }

        public static string Decrypt(string source)
        {
            if (string.IsNullOrWhiteSpace(source)) {
                return string.Empty;
            }
            byte[] sourceByte = Convert.FromBase64String(source);
            byte[] keyByte = Encoding.UTF8.GetBytes(keyInfo);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = keyByte;
            provider.IV = keyByte;

            MemoryStream stream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(sourceByte, 0, sourceByte.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
