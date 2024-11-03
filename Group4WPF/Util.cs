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
                MessageBox.Show("Create successful");
            } catch (Exception ex) {
                string msg = "Error during creation:\n" + ex.Message + "\n";
                while (ex.InnerException != null)
                {
                    msg += ex.InnerException.Message + "\n";
                    ex = ex.InnerException;
                }
                MessageBox.Show(msg);
            }
        }

        public static void TryDelete(Action action)
        {
            try
            {
                action.Invoke();
                MessageBox.Show("Delete successfull");
            }
            catch (Exception ex)
            {
                string msg = "Error during deletion:\n" + ex.Message + "\n";
                while (ex.InnerException != null)
                {
                    msg += ex.InnerException.Message + "\n";
                    ex = ex.InnerException;
                }
                MessageBox.Show(msg);
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
