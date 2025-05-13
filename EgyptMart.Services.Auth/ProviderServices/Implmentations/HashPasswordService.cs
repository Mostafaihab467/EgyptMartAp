using System.Security.Cryptography;

namespace EgyptMart.Services.Auth.ProviderServices
{
    public class HashPasswordService : IHashPasswordService
    {
        private const int SaltSize = 16; // 128 bits
        private const int HashSize = 32; // 112 bits (Changed to 14 to make total 30 bytes)
        private const int Iterations = 1000; // Number of iterations

        public string HashedPassword(string password)
        {
            byte[] salt = GenerateSalt();
            byte[] hash = GenerateHash(password, salt);

            byte[] combinedHash = CombineHashAndSalt(hash, salt);
            string hashedPassword = Convert.ToBase64String(combinedHash);

            return hashedPassword;
        }



        public bool VerifyHashedPassword(string password, string hashedPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hashedPassword))
                {
                    Console.WriteLine("Error: The provided hashed password is null or empty.");
                    return false;
                }

                byte[] combinedHash = Convert.FromBase64String(hashedPassword);

                if (combinedHash.Length != SaltSize + HashSize)
                {
                    Console.WriteLine("Error: The provided hashed password has an invalid length.");
                    return false;
                }

                byte[] salt = new byte[SaltSize];
                Array.Copy(combinedHash, 0, salt, 0, SaltSize);

                byte[] storedHash = new byte[HashSize];
                Array.Copy(combinedHash, SaltSize, storedHash, 0, HashSize);

                byte[] computedHash = GenerateHash(password, salt);

                return CompareHashes(storedHash, computedHash);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid Base64 string. {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error during password verification: {ex.Message}");
                return false;
            }
        }


        private static bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            // Use constant-time comparison to prevent timing attacks
            if (hash1.Length != hash2.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < hash1.Length; i++)
            {
                diff |= hash1[i] ^ hash2[i];
            }

            return diff == 0;
        }


        private static byte[] CombineHashAndSalt(byte[] hash, byte[] salt)
        {
            byte[] combinedHash = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, combinedHash, 0, SaltSize);
            Array.Copy(hash, 0, combinedHash, SaltSize, HashSize);
            return combinedHash;
        }

        private static byte[] GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private static byte[] GenerateHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                // Get 14-byte hash instead of the default 32-byte hash
                var pfk2 = pbkdf2.GetBytes(HashSize);
                return pfk2;
            }
        }
    }
}
