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
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerAddComponentWindow window = new();
            window.Show();
        }
        
        private void ManageComponent_Click(object sender, RoutedEventArgs e){
            this.Close();
            ManagerManageComponentWindow window = new();
            window.Show();
        }
        private void AddExamSchedule_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerAddExamWindow window = new();
            window.Show();
        }
        private void ManageExam_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerManageExamWindow window = new();
            window.Show();
        }
        private void ManageAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerManageAccountWindow window = new();
            window.Show();
        }

    }
}
