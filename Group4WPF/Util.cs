using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group4WPF
{
    public class Util
    {
        public static void TryCreate(Action action)
        {
            try
            {
                action.Invoke();
            } catch (Exception ex) {
                MessageBox.Show("Error during deletion:\n" + ex.Message);
            }
        }

        public static void TryDelete(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during deletion:\n" + ex.Message);
            }
        }

        public static void HideAndOpenWindow(Window current, Window window)
        {
            current.Hide();
            window.Show();
        }

        public static void CloseAndOpenWindow(Window current, Window window)
        {
            current.Close();
            window.Show();
        }

    }
}
