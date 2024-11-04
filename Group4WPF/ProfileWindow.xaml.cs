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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private readonly Window prev;
        private readonly ScheduleService scheduleService;
        private readonly Account _account;

        public ProfileWindow(Window window, Account account)
        {
            InitializeComponent();
            txtWelcome.Content = "WELCOME"; // txtWelcome.Content = "WELCOME" + Account.Name;
            this.prev = window;
            scheduleService = new ScheduleService();
            _account = account;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ScheduleData.ItemsSource = scheduleService.GetSchedulesByAccountId(_account.AccountId); 
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Util.HideAndOpenWindow(this, new ProfileUpdateWindow());
        }

        private void ButtonChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Util.HideAndOpenWindow(this, new ProfileChangePasswordWindow(this, _account));
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            Util.HideAndOpenWindow(this, new ProfileRegisterWindow());
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Util.CloseAndOpenWindow(this, prev);
        }
    }
}
