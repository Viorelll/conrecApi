using System;
using System.Text;
using Conrec.Cryptography.SHA512;

namespace Conrec.Cryptography
{
    public class PasswordManager
    {
        private ICryptHash cryptHash;
        private byte[] saltBytes;
        public PasswordManager(ICryptHash cryptHash)
        {
            this.cryptHash = cryptHash;
        }

        public string EncryptPassword(string plainText, string salt)
        {
            if (string.IsNullOrWhiteSpace(plainText) || string.IsNullOrWhiteSpace(salt))
                throw new Exception("Invalid email or password");

           ApplySalt(salt);

            return cryptHash.ComputeHash(plainText, saltBytes);
        }

        public bool VerifyPassword(string plainText, string hashValue, string salt)
        {
            if (string.IsNullOrWhiteSpace(plainText) || string.IsNullOrWhiteSpace(salt))
                throw new Exception("Invalid email or password");

            ApplySalt(salt);

            return cryptHash.VerifyHash(plainText, hashValue);
        }

        private void ApplySalt(string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            this.saltBytes = saltBytes;
        }
    }
}
