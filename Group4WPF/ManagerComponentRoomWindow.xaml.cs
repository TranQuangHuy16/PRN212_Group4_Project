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
    /// Interaction logic for ManagerComponentRoomWindow.xaml
    /// </summary>
    public partial class ManagerComponentRoomWindow : Window
    {
        private readonly Window window;
        private readonly RoomService roomService;

        public ManagerComponentRoomWindow(Window window)
        {
            this.window = window;
            roomService = new RoomService();
            InitializeComponent();
        }
         private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(RoomNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                roomService.CreateRoom(new BOs.Room { 
                    RoomName = TextRoom.Text,
                    Status = 0,
                });
                System.Windows.MessageBox.Show("Successfully created room " + TextRoom.Text);
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
                roomService.DeleteRoom(((Room)RoomData.SelectedItem).RoomId);
                System.Windows.MessageBox.Show("Deleted room " + ((Room)RoomData.SelectedItem).RoomName);
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
            RoomData.ItemsSource = roomService.GetRooms().Select((c) => c.RoomName.Contains(search));
        }

    }
}
