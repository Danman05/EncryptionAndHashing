using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption.Encryptors
{
    internal class AesGcmCryptoServiceProvider
    {
        // Fields
        private byte[] _key;
        private AesGcm _aesGcm;
        private byte[] _plainText;
        private byte[] _nonce;
        private byte[] _cipherText;
        private byte[] _tag;

        // Constructor
        public AesGcmCryptoServiceProvider(string message)
        {
            _key = new byte[32];
            RandomNumberGenerator.Fill(_key);
            _aesGcm = new AesGcm(_key);
            _plainText = Encoding.UTF8.GetBytes(message);
            _nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
            RandomNumberGenerator.Fill(_nonce);
            _cipherText = new byte[_plainText.Length];
            _tag = new byte[AesGcm.TagByteSizes.MaxSize];
        }

        /// <summary>
        /// AesGcm Encrypt
        /// </summary>
        /// <returns></returns>
        internal byte[] AesgcmEncrypt()
        {
            _aesGcm.Encrypt(_nonce, _plainText, _cipherText, _tag);
            return _plainText;
        }

        /// <summary>
        /// AesGcm Decrypt
        /// </summary>
        /// <returns></returns>
        internal string AesgcmDecrypt()
        {
            byte[] decryptedPlainText = new byte[_cipherText.Length];
            _aesGcm.Decrypt(_nonce, _cipherText, _tag, _plainText);
            string decryptedMessage = Encoding.UTF8.GetString(decryptedPlainText);
            return decryptedMessage;
        }
    }

}
