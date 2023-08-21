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

namespace WpfAppCourse
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClassClients SelectedClient { get; private set; }
        public ClassReservations Reserv { get; private set; }

        public ClientWindow(ClassReservations reserv)
        {
            InitializeComponent();
            Reserv = reserv;
            DataContext = Reserv;
        }

        

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            
            SelectedClient = (ClassClients)ClientComboBox.SelectedItem;
            Reserv.BookingStart = DatePickerStart.SelectedDate.ToString();
            Reserv.BookingEnd = DatePickerEnd.SelectedDate.ToString();

            DialogResult = true;
        }
    }
}
