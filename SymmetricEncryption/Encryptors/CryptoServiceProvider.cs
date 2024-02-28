using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SymmetricEncryption.Encryptors
{
    public class CryptoServiceProvider
    {

        public byte[] EncryptStringToBytes(SymmetricAlgorithm algorithm, string plainText)
        {
            // Check arguments
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (algorithm.Key == null || algorithm.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (algorithm.IV == null || algorithm.IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;
            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

            // Create the streams used for encryption.
            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                //Write all data to the stream.
                swEncrypt.Write(plainText);
            }
            encrypted = msEncrypt.ToArray();

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        public string DecryptBytesToString(SymmetricAlgorithm algorithm, byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (algorithm.Key == null || algorithm.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (algorithm.IV == null || algorithm.IV.Length <= 0)
                throw new ArgumentNullException("IV");


            // Declare the string used to hold the decrypted text.
            string plaintext = null;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

            // Create the streams used for encryption.
            using MemoryStream msDecrypt = new MemoryStream(cipherText);
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using (StreamReader swDecrypt = new(csDecrypt))
            {
                //Write all data to the stream.
               plaintext = swDecrypt.ReadToEnd();
            }

            // Return the encrypted bytes from the memory stream.
            return plaintext;
        }
    }
}
