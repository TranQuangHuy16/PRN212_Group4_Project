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
    /// Interaction logic for ManagerManageExamWindow.xaml
    /// </summary>
    public partial class ManagerManageExamWindow : Window
    {
        private readonly Window _window;
        private readonly AccountService accountService;
        private readonly CourseService courseService;
        private readonly RoomService roomService;
        private readonly SlotService slotService;
        private readonly ScheduleService scheduleService;
        private readonly Schedule _schedule;

        public ManagerManageExamWindow(Window window, Schedule schedule)
        {
            InitializeComponent();
            _window = window;
            _schedule = schedule;
            accountService = new AccountService();
            courseService = new CourseService();
            roomService = new RoomService();
            slotService = new SlotService();
            scheduleService = new ScheduleService();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtScheduleDate.Text = ScheduleDatepicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Account> accounts = accountService.GetAccounts();
            AccountComboBox.ItemsSource = accounts;
            AccountComboBox.SelectedIndex = accounts.FindIndex(0, 1, (account) => account.AccountId == _schedule.AccountId);

            List<string> status = ["Enabled", "Disabled"];
            StatusComboBox.ItemsSource = status;
            StatusComboBox.SelectedIndex = _schedule.Status;

            List<Course> courses = courseService.GetCourses();
            CourseComboBox.ItemsSource = courses;
            CourseComboBox.SelectedIndex = courses.FindIndex(0, 1, (course) => course.CourseId == _schedule.CourseId);

            List<Room> rooms = roomService.GetRooms();
            RoomComboBox.ItemsSource = rooms;
            RoomComboBox.SelectedIndex = rooms.FindIndex(0, 1, (room) => room.RoomId == _schedule.RoomId);

            List<Slot> slots = slotService.GetSlots();
            SlotComboBox.ItemsSource = slots;
            SlotComboBox.SelectedItem = slots.FindIndex(0, 1, (slot) => slot.SlotId == _schedule.SlotId);

            ScheduleDatepicker.SelectedDate = _schedule.ScheduleDate;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _schedule.AccountId = ((Account)AccountComboBox.SelectedItem).AccountId;
            _schedule.Status = (byte)StatusComboBox.SelectedIndex;
            _schedule.CourseId = ((Course)CourseComboBox.SelectedItem).CourseId;
            _schedule.RoomId = ((Room)RoomComboBox.SelectedItem).RoomId;
            _schedule.SlotId = ((Slot)SlotComboBox.SelectedItem).SlotId;
            scheduleService.UpdateScheduled(_schedule);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Util.TryDelete(() =>
            {
                scheduleService.DeleteScheduled(_schedule.ScheduleId);
            })) ButtonCancel_Click(sender, e);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Util.CloseAndOpenWindow(this, _window);
        }
    }
}
