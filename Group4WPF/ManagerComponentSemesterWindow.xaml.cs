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
    /// Interaction logic for ManagerComponentSemesterWindow.xaml
    /// </summary>
    public partial class ManagerComponentSemesterWindow : Window
    {   
        private readonly Window window;
        private readonly SemesterService semesterService;

        public ManagerComponentSemesterWindow()
        {   
            this.window = window;
            semesterService = new SemesterService();
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(SemesterNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                semesterService.CreateSemester(new BOs.Semester { 
                    SemesterName = TextSemester.Text,
                    StartDate = StartDatePicker.SelectedDate.Value,
                    EndDate = EndDatePicker.SelectedDate.Value,
                });
                System.Windows.MessageBox.Show("Successfully created semester " + TextSemester.Text);
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
                semesterService.DeleteSemester(((Semester)SemesterData.SelectedItem).SemesterId);
                System.Windows.MessageBox.Show("Deleted semester " + ((Semester)SemesterData.SelectedItem).SemesterName);
            });
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var search = PlaceholderTextBlock.Text;
            SemesterData.ItemsSource = semesterService.GetSemesters().Select((c) => c.SemesterName.Contains(search));
        }


    }
}
