using BLL;
using BOs;
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
        private readonly SlotService slotService;
        private readonly CourseService courseService;
        private readonly SemesterService semesterService;
        private readonly RoomService roomService;
        private readonly CourseSemesterService courseSemesterService;
        private readonly Window _window;

        public ManagerAddComponentWindow(Window window)
        {
            slotService = new SlotService();
            courseService = new CourseService();
            semesterService = new SemesterService();
            roomService = new RoomService();
            courseSemesterService = new CourseSemesterService();
            InitializeComponent();
            LoadTimeOptions();
            _window = window;
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

        private void LoadSelections()
        {
            SemesterComboBox.ItemsSource = semesterService.GetSemesters();
            CourseComboBox.ItemsSource = courseService.GetCourses();
        }

        private void ButtonCreateCourseSemester_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() => {
                courseSemesterService.CreateCourseSemester(new CourseSemester
                {
                    CourseId = ((Course)CourseComboBox.SelectedItem).CourseId,
                    SemesterId = ((Semester)SemesterComboBox.SelectedItem).SemesterId,
                });
                LoadSelections();
                resetInput();
            });   
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            _window.Show();
        }

        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            ButtonCancel_Click(sender, e); // Yes the done button is cancel button
        }

        private void ButtonCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                roomService.CreateRoom(new Room
                {
                    RoomName = TextRoom.Text,
                });
                resetInput();
            });
        }

        private void ButtonCreateSemester_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() => {
                semesterService.CreateSemester(new Semester { 
                    SemesterName = TextSemester.Text,
                    StartDate = StartDatePicker.SelectedDate.Value,
                    EndDate = EndDatePicker.SelectedDate.Value,
                    Status = 0,
                });
                LoadSelections();
                resetInput();
            });
        }

        private void ButtonCreateCourse_Click(object sender, RoutedEventArgs e)
        {
           Util.TryCreate(() => {
                courseService.CreateCourse(new Course
                {
                    CourseName = TextCourse.Text,
                });
               resetInput();
           });

        }

        private void ButtonCreateSlot_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() => {
                slotService.CreateSlot(new Slot
                {
                    SlotName = TextSlot.Text,
                    StartTime = TimeSpan.Parse(StartTimeComboBox.Text),
                    EndTime = TimeSpan.Parse(EndTimeComboBox.Text),
                });
                LoadSelections();
                resetInput();
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSelections();
        }

        private void resetInput()
        {
            TextSlot.Text = string.Empty;
            StartTimeComboBox.SelectedValue = string.Empty;
            EndTimeComboBox.SelectedValue = string.Empty;
            TextCourse.Text = string.Empty;
            TextSemester.Text = string.Empty;
            StartDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
            TextRoom.Text = string.Empty;
            TextSemester.Text = string.Empty;
            CourseComboBox.SelectedValue = string.Empty;
            SemesterComboBox.SelectedValue = string.Empty;
        }
    }
}
