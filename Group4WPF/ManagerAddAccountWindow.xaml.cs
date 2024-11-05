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

namespace Group4WPF
{
    /// <summary>
    /// Interaction logic for ManagerAddAccountWindow.xaml
    /// </summary>
    public partial class ManagerAddAccountWindow : Window
    {
        private readonly Window _window;
        private readonly AccountService service;

        public ManagerAddAccountWindow(Window prev)
        {
            _window = prev;
            service = new AccountService();
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!TextPassword.Password.Equals(TextPasswordConfirm.Password))
            {
                MessageBox.Show("Password and Confirm Password does not match...");
                return;
            }
            try
            {
                service.CreateAccount(GetAccount());
                MessageBox.Show("Account create successfully");
                HandleClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create account...\n" + ex.Message);
            }
        }

        private Account GetAccount()
        {
            Account account = new()
            {
                Name = TextName.Text,
                Email = TextEmail.Text,
                Telephone = TextTele.Text,
                Password = TextPassword.Password,
                Status = 0,
                Role = 0,
            };
            return account;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            HandleClose();
        }

        private void HandleClose()
        {
            this.Close();
            _window.Show();
        }
    }
}
