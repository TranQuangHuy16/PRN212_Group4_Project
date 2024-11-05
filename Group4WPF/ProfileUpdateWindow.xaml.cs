using BLL;
using BOs;
using Group4WPF;
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
    /// Interaction logic for ProfileUpdateWindow.xaml
    /// </summary>
    public partial class ProfileUpdateWindow : Window
    {
        private readonly Window _window;
        private readonly Account _account;
        private readonly AccountService _accountService;

        public ProfileUpdateWindow(Window window, Account account)
        {
            InitializeComponent();
            _window = window;
            _account = account;
            _accountService = new();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryUpdate(() => { 
                _account.Name = TextName.Text;
                _account.Email = TextEmail.Text;
                _account.Telephone = TextTele.Text;
                _accountService.UpdateAccount(_account);
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Util.CloseAndOpenWindow(this, _window);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextName.Text = _account.Name;
            TextEmail.Text = _account.Email;
            TextTele.Text = _account.Telephone;
        }
    }
}
