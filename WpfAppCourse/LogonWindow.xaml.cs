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
using WpfApp16;

namespace WpfAppCourse
{
    /// <summary>
    /// Логика взаимодействия для LogonWindow.xaml
    /// </summary>
    public partial class LogonWindow : Window
    {
        private Dictionary<string, string> receptionistLogin;
        private Dictionary<string, string> adminLogin;

        public LogonWindow()
        {
            InitializeComponent();
            LoadLoginFromDatabase();
        }

        private void LoadLoginFromDatabase()
        {
            receptionistLogin = new Dictionary<string, string>();
            adminLogin = new Dictionary<string, string>();

            using (ApplicationContext db = new ApplicationContext())
            {
                var logEntries = db.Login.ToList();

                foreach (var entry in logEntries)
                {
                    string email = entry.Email;
                    string password = entry.Password;
                    string jobTitle = entry.JobTitle;

                    if (jobTitle == "Receptionist")
                    {
                        receptionistLogin[email] = password;
                    }
                    else if (jobTitle == "Admin")
                    {
                        adminLogin[email] = password;
                    }
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = new System.Net.NetworkCredential(string.Empty, PasswordBox.SecurePassword).Password;

            if (receptionistLogin.ContainsKey(email) && receptionistLogin[email] == password)
            {
                MainWindow receptionistMainWindow = new MainWindow("Receptionist");
                receptionistMainWindow.Show();
                this.Hide();
            }
            else if (adminLogin.ContainsKey(email) && adminLogin[email] == password)
            {
                MainWindow adminMainWindow = new MainWindow("Admin");
                adminMainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

