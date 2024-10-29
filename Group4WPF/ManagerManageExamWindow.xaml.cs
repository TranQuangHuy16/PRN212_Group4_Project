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
    /// Interaction logic for ManagerManageExamWindow.xaml
    /// </summary>
    public partial class ManagerManageExamWindow : Window
    {
        public ManagerManageExamWindow()
        {
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtScheduleDate.Text = ScheduleDatepicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }
    }
}
