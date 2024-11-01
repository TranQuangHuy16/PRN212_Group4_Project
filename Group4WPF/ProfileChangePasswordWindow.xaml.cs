using BLL;
using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProfileChangePasswordWindow.xaml
    /// </summary>
    public partial class ProfileChangePasswordWindow : Window
    {
        private readonly Window _window;
        private readonly Account _account;
        private readonly AccountService accountService;

        public ProfileChangePasswordWindow(Window window, Account account)
        {
            InitializeComponent();
            _window = window;
            _account = account;
            accountService = new AccountService();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (_account.Password.Equals(TextPassword.Password))
            {
                if (TextPasswordNew.Password.Equals(TextPasswordConfirm.Password))
                {
                    _account.Password = TextPasswordNew.Password;
                    MessageBox.Show("Password updated");
                }
                else
                {
                    MessageBox.Show("Confirm password does not match...");
                }
            } else
            {
                MessageBox.Show("Current password is incorrect...");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            _window.Show();
        }
    }
}
