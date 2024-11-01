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
    /// Interaction logic for ManagerManageExamWindow.xaml
    /// </summary>
    public partial class ManagerManageExamWindow : Window
    {
        private readonly Window _window;
        private readonly SemesterService semesterService;
        private readonly CourseService courseService;
        private readonly RoomService roomService;
        private readonly SlotService slotService;

        public ManagerManageExamWindow(Window window)
        {
            InitializeComponent();
            _window = window;
            semesterService = new SemesterService();
            courseService = new CourseService();
            roomService = new RoomService();
            slotService = new SlotService();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtScheduleDate.Text = ScheduleDatepicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SemesterComboBox.ItemsSource = semesterService.GetSemesters();
            List<String> status = ["Enabled", "Disabled"];
            StatusComboBox.ItemsSource = status;
            CourseComboBox.ItemsSource = courseService.GetCourses();
            RoomComboBox.ItemsSource = roomService.GetRooms();
            SlotComboBox.ItemsSource = slotService.GetSlots();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Exam
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Util.CloseAndOpenWindow(this, _window);
        }
    }
}
