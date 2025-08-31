using Microsoft.AspNetCore.Identity;
using resturangApi.Services.Iservices;
using System.Security.Cryptography;

namespace resturangApi.Services

{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;
        private readonly HashAlgorithmName _HashAlgorithm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _HashAlgorithm, HashSize);

            return $"{Convert.ToHexString(hash)}.{Convert.ToHexString(salt)}";
        }
        public bool Verify(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash))
                throw new ArgumentException("Hash cannot be null or empty.", nameof(hash));

            var parts = hash.Split('.');

            if (parts.Length != 2)
                throw new FormatException("Invalid hash format. Expected format: [hash].[salt]");

            byte[] hashBytes, salt;

            try
            {
                hashBytes = Convert.FromHexString(parts[0]);
                salt = Convert.FromHexString(parts[1]);
            }
            catch (FormatException)
            {
                throw new FormatException("Hash or salt is not a valid hex string.");
            }

            var newHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _HashAlgorithm, HashSize);

            return CryptographicOperations.FixedTimeEquals(hashBytes, newHash);
        }

    }
}

