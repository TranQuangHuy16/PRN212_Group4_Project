using BLL;
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
        public ManagerWindow(Window window)
        {
            this.prev = window;
            InitializeComponent();
            scheduleService = new ScheduleService();
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
            ManagerAddExamWindow window = new();
            window.Show();
        }
        private void ManageExam_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManagerManageExamWindow window = new(this);
            window.Show();
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
            ScheduleData.ItemsSource = scheduleService.GetSchedules();
        }
    }
}
