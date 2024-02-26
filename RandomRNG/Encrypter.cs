using System.Text;

namespace RandomRNG
{
    /// <summary>
    /// Provides encryption and decryption using a simple substitution cipher.
    /// </summary>
    public class Encrypter
    {
        /// <summary>
        /// The first substitution table (plaintext alphabet).
        /// </summary>
        public static string firstTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";

        /// <summary>
        /// The second substitution table (cipher alphabet).
        /// </summary>
        public static string secondTable = "KLMNOPQRSTUVWXYZÆØÅABCDEFGHIJ";

        /// <summary>
        /// Encrypts a given string using the substitution cipher.
        /// </summary>
        /// <param name="str">The string to be encrypted.</param>
        /// <returns>The encrypted string.</returns>
        internal static string EncryptString(string str)
        {
            StringBuilder sb = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in str.ToUpper())
            {
                // Find the index of the character in the first substitution table
                int index = firstTable.IndexOf(c);

                // If the character is found, append the corresponding character from the second table
                if (index != -1)
                {
                    sb.Append(secondTable[index]);
                }
                else
                {
                    // If the character is not found, append it unchanged
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decrypts a given string that was encrypted using the substitution cipher.
        /// </summary>
        /// <param name="str">The string to be decrypted.</param>
        /// <returns>The decrypted string.</returns>
        internal static string DecryptString(string str)
        {
            StringBuilder sb = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in str.ToUpper())
            {
                // Find the index of the character in the second substitution table
                int index = secondTable.IndexOf(c);

                // If the character is found, append the corresponding character from the first table
                if (index != -1)
                {
                    sb.Append(firstTable[index]);
                }
                else
                {
                    // If the character is not found, append it unchanged
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
