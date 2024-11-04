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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private readonly Window prev;
        private readonly ScheduleService scheduleService;
        private readonly Account _account;

        public ManagerWindow(Window window, Account account)
        {
            this.prev = window;
            InitializeComponent();
            scheduleService = new ScheduleService();
            _account = account;
        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManagerAddComponentWindow window = new(this);
            window.Show();
        }
        
        private void ManageComponent_Click(object sender, RoutedEventArgs e){
            this.Hide();
            ManagerManageComponentWindow window = new(this);
            window.Show();
        }
        private void AddExamSchedule_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManagerAddExamWindow window = new(this, _account);
            window.Show();
        }
        private void ManageExam_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleData.SelectedItem is not Schedule schedule)
            {
                MessageBox.Show("No schedule selected");
                return;
            }
            Util.HideAndOpenWindow(this, new ManagerManageExamWindow(this, schedule));
        }
        private void ManageAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManagerManageAccountWindow window = new(this);
            window.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            prev.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ScheduleData.ItemsSource = scheduleService.GetSchedules();
        }

        private void ScheduleData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScheduleData.SelectedItem is not Schedule schedule || 
                schedule.Account is not Account account)
            {
                TextName.Text = string.Empty;
                TextEmail.Text = string.Empty;
                return;
            }
            TextName.Text = account.Name;
            TextEmail.Text = account.Email;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
