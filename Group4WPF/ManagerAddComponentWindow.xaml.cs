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
    /// Interaction logic for ManagerAddComponentWindow.xaml
    /// </summary>
    public partial class ManagerAddComponentWindow : Window
    {
        public ManagerAddComponentWindow()
        {
            InitializeComponent();
            LoadTimeOptions();
        }

        private void LoadTimeOptions()
        {
            List<string> timeOptions = new List<string>();

            for (int hour = 7; hour <= 23; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30)
                {
                    string time = $"{hour:D2}:{minute:D2}";
                    timeOptions.Add(time);
                }
            }

            StartTimeComboBox.ItemsSource = timeOptions;
            EndTimeComboBox.ItemsSource = timeOptions;
        }

        private void ButtonCreateCourseSemester_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCreateRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCreateCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCreateSlot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
