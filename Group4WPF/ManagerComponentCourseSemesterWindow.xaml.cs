using BLL;
using BOs;
using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for ManagerComponentCourseSemesterWindow.xaml
    /// </summary>
    public partial class ManagerComponentCourseSemesterWindow : Window
    {
        private readonly CourseService courseService;
        private readonly SemesterService semesterService;
        private readonly CourseSemesterService courseSemesterService;

        public ManagerComponentCourseSemesterWindow()
        {
            courseService = new CourseService();
            semesterService = new SemesterService();
            courseSemesterService = new CourseSemesterService();
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(CourseNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
            UpdateSearchResult();
        }

        private void UpdateSearchResult()
        {
            string search = CourseNameTextBox.Text;
            CourseSemesterData.ItemsSource = courseSemesterService.GetCourseSemesters()
                .Select((cs) => cs.Semester.SemesterName.Contains(search) || cs.Course.CourseName.Contains(search));
        }

        private void LoadSelections()
        {
            SemesterComboBox.ItemsSource = semesterService.GetSemesters();
            CourseComboBox.ItemsSource = courseService.GetCourses();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() => {
                if (CourseComboBox.SelectedItem is Course course && SemesterComboBox.SelectedItem is Semester semester)
                {
                    courseSemesterService.CreateCourseSemester(new CourseSemester { 
                        Course = course,
                        Semester = semester,
                    });
                }
                else
                {
                    MessageBox.Show("Course or Semester is not selected");
                }
                UpdateSearchResult();
            });    
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Create update window
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CourseComboBox.SelectedItem is Course course && SemesterComboBox.SelectedItem is Semester semester)
            {
                courseSemesterService.DeleteCourseSemester(course.CourseId, semester.SemesterId);
            }
            else
            {
                MessageBox.Show("Course or Semester is not selected");
            }
            UpdateSearchResult();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSelections();
        }
    }
}
