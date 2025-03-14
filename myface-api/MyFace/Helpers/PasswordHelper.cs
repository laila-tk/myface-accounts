using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace MyFace.Helpers
{
    public static class PasswordHelper
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = System.Security.Cryptography.RandomNumberGenerator.GetBytes(128 / 8);
            return salt;
        }
        public static string Hashpassword(byte[] salt, string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        }

    }

}




