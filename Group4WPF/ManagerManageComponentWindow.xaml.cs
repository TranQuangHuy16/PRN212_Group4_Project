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
    /// Interaction logic for ManagerManageComponentWindow.xaml
    /// </summary>
    public partial class ManagerManageComponentWindow : Window
    {
        private readonly Window _window;
        public ManagerManageComponentWindow(Window window)
        {
            InitializeComponent();
            _window = window;
        }

        private void ButtonRoom_Click(object sender, RoutedEventArgs e)
        {
            HideAndOpenWindow(new ManagerComponentRoomWindow(this));            
        }

        private void ButtonSlot_Click(object sender, RoutedEventArgs e)
        {
            HideAndOpenWindow(new ManagerComponentSlotWindow(this));
        }

        private void Semester_Click(object sender, RoutedEventArgs e)
        {
            HideAndOpenWindow(new ManagerComponentSemesterWindow(this));
        }

        private void Course_Click(object sender, RoutedEventArgs e)
        {
            HideAndOpenWindow(new ManagerComponentCourseWindow(this));
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            HideAndOpenWindow(_window);
        }

        private void HideAndOpenWindow(Window window)
        {
            Hide();
            window.Show();
        }
    }
}
