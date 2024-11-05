using BLL;
using BOs;
using DAL;
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
        private readonly CourseService courseService;
        private readonly RoomService roomService;
        private readonly SlotService slotService;
        private readonly SemesterService semesterService;
        private readonly ScheduleService scheduleService;
        private readonly Window _window;
        private readonly Account _account;

        public ManagerAddExamWindow(Window window, Account account)
        {
            courseService = new CourseService();
            roomService = new RoomService();
            slotService = new SlotService();
            semesterService = new SemesterService();
            scheduleService = new ScheduleService();
            InitializeComponent();
            _window = window;
            _account = account;
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
            //SemesterComboBox.ItemsSource = semesterService.GetSemesters();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() => {
                scheduleService.CreateScheduled(new BOs.Schedule
                {
                    /*CourseSemester = courseSemesterService.GetCourseSemesters()
                        .First((cs) => 
                            cs.SemesterId == ((BOs.Semester)SemesterComboBox.SelectedItem).SemesterId &&
                            cs.CourseId == ((BOs.Course)CourseComboBox.SelectedItem).CourseId 
                            ),*/
                    SemesterId = ((BOs.Semester)SemesterComboBox.SelectedItem).SemesterId,
                    CourseId = ((BOs.Course)CourseComboBox.SelectedItem).CourseId,
                    RoomId = ((Room)RoomComboBox.SelectedItem).RoomId,
                    SlotId = ((Slot)SlotComboBox.SelectedItem).SlotId,
                    //AccountId = _account.AccountId,
                    ScheduleDate = ScheduleDatepicker.SelectedDate.Value,
                    Status = 0,
                });
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Util.CloseAndOpenWindow(this, _window);           
        }

        private void CourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SemesterComboBox.ItemsSource = semesterService.GetSemesterByCourseId(((Course)CourseComboBox.SelectedItem).CourseId);
        }
    }
}
