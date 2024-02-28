using SymmetricEncryption.Encryptors;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymmetricEncryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SymmetricAlgorithm? algorithm;
        private CryptoServiceProvider cryptoProvider;

        private static bool useAesGcm;
        public MainWindow()
        {
            InitializeComponent();
            cryptoProvider = new CryptoServiceProvider();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Upper case string</returns>
        private string ComboSelectedItem()
        {
            ComboBoxItem comboBoxItem = comboBox.SelectedItem as ComboBoxItem;
            return comboBoxItem.Content.ToString()
                .Trim()
                .Replace(" ", "")
                .ToUpper();
        }

        /// <summary>
        /// Encrypts plaintext into a cipher from a given algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string plainText = plainTxtBox.Text;

                if (useAesGcm) // AesGcm - Still testing
                {
                    AesGcmCryptoServiceProvider aesGcm = new AesGcmCryptoServiceProvider(plainText);
                    MessageBox.Show(Convert.ToBase64String(aesGcm.AesgcmEncrypt()));
                    MessageBox.Show(aesGcm.AesgcmDecrypt()); 
                }
                else
                {
                    string cipher = Convert.ToBase64String(cryptoProvider.EncryptStringToBytes(algorithm, plainText));
                    plainTxtLbl.Content = cipher;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Decrypts a cipher from given algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] cipher = Convert.FromBase64String(plainTxtLbl.Content.ToString());
                MessageBox.Show(cryptoProvider.DecryptBytesToString(algorithm, cipher));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Change algorithm from comboBox value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboSelectedItem())
            {
                case "AES":
                    algorithm = Aes.Create();
                    break;
                case "DES":
                    algorithm = DES.Create();
                    break;
                case "TRIPLEDES":
                    algorithm = TripleDES.Create();
                    break;
                case "AESGCM":
                    useAesGcm = true;
                    break;
                default:
                    MessageBox.Show("Error. selected combobox item: " + ComboSelectedItem());
                    break;
            }
        }
    }
}