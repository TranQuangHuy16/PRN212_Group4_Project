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
    /// Interaction logic for ManagerAddExamWindow.xaml
    /// </summary>
    public partial class ManagerAddExamWindow : Window
    {
        public ManagerAddExamWindow()
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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtScheduleDate.Text = ScheduleDatepicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }
    }
}
