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
    /// Interaction logic for ManagerAddExamWindow.xaml
    /// </summary>
    public partial class ManagerAddExamWindow : Window
    {
        private CourseService courseService;
        private RoomService roomService;
        private SlotService slotService;
        private SemesterService semesterService;
        private ScheduleService scheduleService;

        public ManagerAddExamWindow()
        {
            courseService = new CourseService();
            roomService = new RoomService();
            slotService = new SlotService();
            semesterService = new SemesterService();
            scheduleService = new ScheduleService();
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtScheduleDate.Text = ScheduleDatepicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSelections();
        }

        private void LoadSelections()
        {
            CourseComboBox.ItemsSource = courseService.GetCourses();
            RoomComboBox.ItemsSource = roomService.GetRooms();
            SlotComboBox.ItemsSource = slotService.GetSlots();
            SemesterComboBox.ItemsSource = semesterService.GetSemesters();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() => {
                scheduleService.CreateScheduled(new BOs.Schedule
                {
                    SemesterId = ((BOs.Semester)SemesterComboBox.SelectedItem).SemesterId,
                    CourseId = ((BOs.Course)CourseComboBox.SelectedItem).CourseId,
                    Room = (Room)RoomComboBox.SelectedItem,
                    Slot = (Slot)SlotComboBox.SelectedItem,
                    ScheduleDate = ScheduleDatepicker.SelectedDate.Value,
                });
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
