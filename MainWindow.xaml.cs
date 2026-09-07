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

namespace WpfAppAes_Gcm256WithSAlt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>  Das Programm wurde von Ahmad Khaddam erstellt
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string salt = "fsderisohgfdsu5dfgMNSFiu%tsak$uswai54LJHgdNSFiu%tsak$uswafewqqMNhdslipü";
        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            string pass = textPass.Password;
            string normalText = textNormal.Text;
            if (string.IsNullOrEmpty(normalText) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("the item not found");
                return;
            }
            string encryptionTex = Encryptor.getEncrypt(pass, salt, normalText);
            if (string.IsNullOrEmpty(encryptionTex))
            {
                MessageBox.Show("the item not found");
                return;
            }
            textEncrypt.Text = encryptionTex;
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            
            string pass = textPass.Password;
            string encryptText = textEncrypt.Text;
            if(string.IsNullOrEmpty(encryptText) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("the item not found");
                return;
            }
            string decryptText = Encryptor.getDecrypt(pass, salt, encryptText);
            if (string.IsNullOrEmpty(decryptText))
            {
                MessageBox.Show("the item not found");
                return;
            }

            textDecrypt.Text = decryptText;
        }
    }
}
