﻿using BLL;
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

        public ManagerComponentSemesterWindow(Window window)
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
            LoadData();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                semesterService.CreateSemester(new BOs.Semester { 
                    SemesterName = TextSemester.Text,
                    StartDate = StartDatePicker.SelectedDate.Value,
                    EndDate = EndDatePicker.SelectedDate.Value,
                    Status = 0,
                });
                LoadData();
            });
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (SemesterData.SelectedItem is not Semester semester)
            {
                MessageBox.Show("No semester selected");
                return;
            }
            Util.TryUpdate(() =>
            {
                semester.SemesterName = TextSemester.Text;
                semester.StartDate = StartDatePicker.SelectedDate.Value;
                semester.EndDate = EndDatePicker.SelectedDate.Value;
                semesterService.UpdateSemester(semester);
                LoadData();
            });
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Util.TryDelete(() => {
                semesterService.DeleteSemester(((Semester)SemesterData.SelectedItem).SemesterId);
                LoadData();
                TextSemester.Text = string.Empty;
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
            var search = SemesterNameTextBox.Text;
            SemesterData.ItemsSource = semesterService.GetSemesters().Where((c) => c.SemesterName.Contains(search));
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SemesterData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SemesterData.SelectedItem is not Semester semester)
            {
                TextSemester.Text = string.Empty;
                return;
            }
            TextSemester.Text = semester.SemesterName;
            StartDatePicker.SelectedDate = semester.StartDate;
            EndDatePicker.SelectedDate = semester.EndDate;
        }
    }
}
