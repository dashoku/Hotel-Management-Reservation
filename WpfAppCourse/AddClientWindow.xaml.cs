using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {

        public ClassClients Client { get; private set; }
        public ClassReservations Reserv { get; private set; }

        public AddClientWindow(ClassClients client)
        {
            InitializeComponent();
            Client = client;
            DataContext = Client;

            Reserv = new ClassReservations();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Client.ClName = NameTextBox.Text;
            Client.ClSurname = SurnameTextBox.Text;
            Client.ClPatronimic = PatronymicTextBox.Text;
            Client.ClPasportId = PassportIdTextBox.Text;
            Client.ClDateOfBirth = DateOfBirthPicker.SelectedDate.ToString();
            Client.ClCountry = CountryTextBox.Text;
            Client.ClCity = CityTextBox.Text;
            Client.ClAddres = AddressTextBox.Text;
            Client.ClRegistrationDate = RegistrationDatePicker.SelectedDate.ToString(); 
            Client.ClDepartureDate = DepartureDatePicker.SelectedDate.ToString();
            Client.ClWorkStudy = WorkStudyTextBox.Text;
            Client.ClRoomfree = ((ComboBoxItem)RoomFeeComboBox.SelectedItem).Content.ToString();
            Client.ClCashPayment = ((ComboBoxItem)CashPaymentComboBox.SelectedItem).Content.ToString();
            Client.ClReceiptNumber = ReceiptNumberTextBox.Text;
            Client.ClIsVIP = VIPClientCheckBox.IsChecked == true ? "так" : "ні"; 
            Client.ClNotes = NotesTextBox.Text;

            Reserv.Name = NameTextBox.Text;
            Reserv.Surname = SurnameTextBox.Text;

            DialogResult = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = string.Empty;
            SurnameTextBox.Text = string.Empty;
            PatronymicTextBox.Text = string.Empty;
            PassportIdTextBox.Text = string.Empty;
            DateOfBirthPicker.SelectedDate = null;
            CountryTextBox.Text = string.Empty;
            CityTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            RegistrationDatePicker.SelectedDate = null;
            WorkStudyTextBox.Text = string.Empty;
            RoomFeeComboBox.SelectedIndex = -1;
            ReceiptNumberTextBox.Text = string.Empty;
            VIPClientCheckBox.IsChecked = false;
            NotesTextBox.Text = string.Empty;

            DialogResult = false;
        }
    }
}


