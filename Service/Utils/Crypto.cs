using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace FixesBusiness.Utils
{
    public class Crypto
    {

        public static byte[] GetRandomSalt(int length)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        public static byte[] EncryptPassword(byte[] password, byte[] salt)
        {
            HashAlgorithm hashAlgorithm = new SHA512Managed();
            byte[] plainTextWithSaltBytes = new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
                plainTextWithSaltBytes[i] = password[i];
            for (int i = 0; i < salt.Length; i++)
                plainTextWithSaltBytes[password.Length + i] = salt[i];

            return hashAlgorithm.ComputeHash(plainTextWithSaltBytes);
        }

    }
}



