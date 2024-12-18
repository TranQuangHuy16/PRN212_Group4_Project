﻿using BLL;
using BOs;
using Group4WPF;
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
            try
            {
                var email = TextEmail.Text;
                var password = TextPassword.Password;
                Account account = service.GetAccountByEmail(email);
                if (account != null && account.Password.Equals(password))
                {
                    if (account.Role == 0)
                    {
                        Util.HideAndOpenWindow(this, new ManagerWindow(this, account));
                    } else
                    {
                        Util.HideAndOpenWindow(this, new ProfileWindow(this, account));
                    }
                }
                else
                {
                    SendInvalidLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void SendInvalidLogin() => MessageBox.Show("Email or Password is incorrect");

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}