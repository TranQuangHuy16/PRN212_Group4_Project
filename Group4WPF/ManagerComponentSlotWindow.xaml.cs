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
    /// Interaction logic for ManagerComponentSlotWindow.xaml
    /// </summary>
    public partial class ManagerComponentSlotWindow : Window
    {
        private readonly Window window;
        private readonly SlotService slotService;

        public ManagerComponentSlotWindow(Window window)
        {this.window = window;
            slotService = new SlotService();

            InitializeComponent();
            LoadTimeOptions();
        }

        private void LoadTimeOptions()
        {
            List<string> timeOptions = [];

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


         private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(TextSlot.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                slotService.CreateSlot(new BOs.Slot
                {
                    SlotName = TextSlot.Text,
                    StartTime = TimeSpan.Parse((string)StartTimeComboBox.SelectedItem),
                    EndTime = TimeSpan.Parse((string)EndTimeComboBox.SelectedItem),
                    Status = 0,
                });
                System.Windows.MessageBox.Show("Successfully created slot " + TextSlot.Text);
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
                slotService.DeleteSlot(((Slot)SlotData.SelectedItem).SlotId);
                MessageBox.Show("Deleted slot " + ((Slot)SlotData.SelectedItem).SlotName);
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
            var search = SlotNameTextBox.Text;
            SlotData.ItemsSource = slotService.GetSlots().Where((c) => c.SlotName.Contains(search));
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
