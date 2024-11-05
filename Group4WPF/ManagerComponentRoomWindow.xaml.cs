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
            InitializeComponent();
            this.window = window;
            roomService = new RoomService();
        }
         private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(RoomNameTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
            LoadData();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Util.TryCreate(() =>
            {
                roomService.CreateRoom(new BOs.Room { 
                    RoomName = TextRoom.Text,
                    Status = 0,
                });
                LoadData();
            });
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (RoomData.SelectedItem is not Room room) {
                MessageBox.Show("No room selected");
                return; 
            }
            Util.TryUpdate(() =>
            {
                room.RoomName = TextRoom.Text;
                roomService.UpdateRoom(room);
                LoadData();
            });
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Util.TryDelete(() => {
                roomService.DeleteRoom(((Room)RoomData.SelectedItem).RoomId);
                LoadData();
                TextRoom.Text = string.Empty;
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
            var search = RoomNameTextBox.Text;
            RoomData.ItemsSource = roomService.GetRooms().Where((c) => c.RoomName.Contains(search));
        }

        private void RoomData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomData.SelectedItem is not Room room)
            {
                TextRoom.Text = string.Empty;
                return;
            }
            TextRoom.Text = room.RoomName;

        }
    }
}
