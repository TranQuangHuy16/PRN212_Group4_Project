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
    /// Interaction logic for ManagerManageAccountWindow.xaml
    /// </summary>
    public partial class ManagerManageAccountWindow : Window
    {
        private readonly AccountService accountService;
        private readonly Window _window;

        public ManagerManageAccountWindow(Window _window)
        {
            this._window = _window;
            accountService = new AccountService();

            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(AccountNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
            LoadData();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.HideAndOpenWindow(this, new ManagerAddAccountWindow(this));    
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (AccountData.SelectedItem is not Account account)
            {
                MessageBox.Show("No account selected");
                return;
            }
            Util.TryUpdate(() => {
                account.Name = TextName.Text;
                account.Email = TextEmail.Text;
                account.Telephone = TextPhone.Text;
                accountService.UpdateAccount(account);
                LoadData();
            });
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Util.TryDelete(() =>
            {
                accountService.DeleteAccount(((Account)AccountData.SelectedItem).AccountId);
                LoadData();
                EmptyTextBox();
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var search = AccountNameTextBox.Text ?? "";
            AccountData.ItemsSource = accountService.GetAccounts().Where((c) => c.Name.Contains(search));
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void EmptyTextBox()
        {
            TextName.Text = string.Empty;
            TextEmail.Text = string.Empty;
            TextPhone.Text = string.Empty;

        }

        private void AccountData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountData.SelectedItem is not Account account)
            {
                EmptyTextBox();
                return;
            }
            TextName.Text = account.Name;
            TextEmail.Text = account.Email;
            TextPhone.Text = account.Telephone;

        }
    }
}
