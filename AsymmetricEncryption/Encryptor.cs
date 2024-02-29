using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricEncryption
{
    internal static class Encryptor
    {
        /// <summary>
        /// Using RSACryptoServiceProvider to encrypt data.
        /// The public key is used to encrypt data
        /// </summary>
        /// <param name="dataToBeEncrypted"></param>
        /// <param name="RsaInfo">This is were keys are stored, the public key is used in this method</param>
        /// <param name="OaedPadding"></param>
        /// <returns>Encrypted Data</returns>
        public static byte[] RsaEncrypt(byte[] dataToBeEncrypted, RSAParameters RsaInfo, bool OaedPadding)
        {
            try
            {
                byte[] encryptedData; // Empty byte[]

                // Using statement, releases all ressources after use
                using RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                
                RSA.ImportParameters(RsaInfo); // Import Rsa parameters such as keys

                // Fill byte[] with encryption result
                encryptedData = RSA.Encrypt(dataToBeEncrypted, OaedPadding);

                return encryptedData;
            }

            // Exception handling
            catch (Exception ex)
            {
                Console.WriteLine($"Encryption failed: {ex.Message}");

                return null;
            }
        }

        /// <summary>
        /// Using RSACryptoServiceProvider to decrypt data.
        /// The private key is used to decrypt
        /// </summary>
        /// <param name="dataToBeDecrypted"></param>
        /// <param name="RsaInfo">An RSAParameter is passed in which is where the keys are stored, private key is used here.</param>
        /// <param name="OaedPadding"></param>
        /// <returns>Decrypted Data</returns>
        public static byte[] RsaDecrypt(byte[] dataToBeDecrypted, RSAParameters RsaInfo, bool OaedPadding)
        {
            try
            {

                byte[] decryptedData; // empty byte[]

                // Using statement, releases all ressources after use
                using RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                RSA.ImportParameters(RsaInfo); // Import Rsa parameters such as keys
                decryptedData = RSA.Decrypt(dataToBeDecrypted, OaedPadding);

                return decryptedData;
            }
            // Exception handling
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption failed: {ex.Message}");

                return null;
            }

        }
    }
}