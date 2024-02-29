using System.Security.Cryptography;
using System.Text;

namespace AsymmetricEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Byte arrays
            byte[] dataToBeEncrypted = Encoding.UTF8.GetBytes("ThisIsASecret");
            byte[] EncryptedData;
            byte[] DecryptedData;

            try
            {
                // Using statement, releases all ressources after use
                using RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                string publicKey = RSA.ToXmlString(false); // Create XML string containing public key
                string privateKey = RSA.ToXmlString(true); // Create XML string containing private key

                // Encrypt data from 
                EncryptedData = Encryptor.RsaEncrypt(dataToBeEncrypted, RSA.ExportParameters(false), false);

                DecryptedData = Encryptor.RsaDecrypt(EncryptedData, RSA.ExportParameters(true), false);

                // Display to console
                Console.WriteLine("Encrypted Text: {0}\nDecrypted Text: {1}",
                    Convert.ToBase64String(EncryptedData),
                    Encoding.UTF8.GetString(DecryptedData));
            }
            // Exception handling
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Encryption failed. data is null: {ex.Message}");
            }
        }
    }
}
