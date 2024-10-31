using BLL;
using BOs;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountService service;

        public MainWindow()
        {
            InitializeComponent();
            service = new AccountService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var email = TextEmail.Text;
            var password = TextPassword.Password;
            Account account = service.GetAccountByEmail(email);
            if (account != null && account.Password.Equals(password))
            {
                this.Hide();
                ManagerWindow window = new(this);
                window.Show();
            }
            else
            {
                SendInvalidLogin();
            }
        }

        private static void SendInvalidLogin() => MessageBox.Show("Email or Password is incorrect");

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}