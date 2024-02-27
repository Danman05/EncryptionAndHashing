using System.Security.Cryptography;

namespace SecurePassword
{
    public class Pbkdf2
    {
        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;
            var randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[saltLength]; // Brug length parameteren til at bestemme antallet af bytes
            randomNumberGenerator.GetBytes(randomBytes);

            return randomBytes;
        }


        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, HashAlgorithmName.SHA256))
            {
                return rfc2898.GetBytes(32);
            };

        }
    }
}
