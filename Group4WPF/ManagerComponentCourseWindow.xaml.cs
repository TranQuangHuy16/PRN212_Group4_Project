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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group4WPF
{
    /// <summary>
    /// Interaction logic for ManagerComponentCourseWindow.xaml
    /// </summary>
    public partial class ManagerComponentCourseWindow : Window
    {
        private readonly CourseService courseService;
        private readonly Window _window;

        public ManagerComponentCourseWindow(Window _window)
        {
            this._window = _window;
            courseService = new CourseService();
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(CourseNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                courseService.CreateCourse(new BOs.Course { 
                    CourseName = TextCourse.Text,
                    Status = 0,
                });
                System.Windows.MessageBox.Show("Successfully created course " + TextCourse.Text);
                LoadData();
            });
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Add update
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Util.TryDelete(() => {
                courseService.DeleteCourse(((Course)CourseData.SelectedItem).CourseId);
                System.Windows.MessageBox.Show("Deleted course " + ((Course)CourseData.SelectedItem).CourseName);
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var search = PlaceholderTextBlock.Text;
            CourseData.ItemsSource = courseService.GetCourses().Select((c) => c.CourseName.Contains(search));
        }
    }
}
