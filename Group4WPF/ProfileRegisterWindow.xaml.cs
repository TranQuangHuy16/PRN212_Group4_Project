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
    /// Interaction logic for ProfileRegisterWindow.xaml
    /// </summary>
    public partial class ProfileRegisterWindow : Window
    {
        private readonly Window _window;
        private readonly ScheduleService _service;
        private readonly Account _account;

        public ProfileRegisterWindow(Window window, Account account)
        {
            InitializeComponent();
            _window = window;
            _account = account;
            _service = new ScheduleService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(CourseNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
            LoadData();
        }

        private void LoadData()
        {
            string search = PlaceholderTextBlock.Text ?? "";
            ScheduleData.ItemsSource = _service.GetSchedules().Where((schedule) => schedule.CourseSemester.Course.CourseName.Equals(search));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleData.SelectedItem is not Schedule schedule) return;
            Util.TryUpdate(() => {
                schedule.AccountId = _account.AccountId;
                _service.UpdateScheduled(schedule);
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Util.CloseAndOpenWindow(this, _window);
        }
    }
}
