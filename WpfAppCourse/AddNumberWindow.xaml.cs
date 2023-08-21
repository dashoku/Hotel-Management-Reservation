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
    /// Interaction logic for AddNumberWindow.xaml
    /// </summary>
    public partial class AddNumberWindow : Window
    {
        public ClassRooms Room { get; private set; }
        public ClassReservations Reserv { get; private set; }

        public AddNumberWindow(ClassRooms room)
        {
            InitializeComponent();
            Room = room;
            this.DataContext = Room;

            Reserv = new ClassReservations();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Room.Number = int.Parse(NumberTextBox.Text);
            Room.Price = PriceTextBox.Text;
            Room.RoomCount = ((ComboBoxItem)NumberOfRoomsSlider.SelectedItem).Content.ToString();
            Room.Floor = int.Parse(((ComboBoxItem)FloorNumberTextBox.SelectedItem).Content.ToString());
            Room.HasTV = TVCheckBox.IsChecked == true ? "так" : "ні";
            Room.HasRefrigerator = RefrigeratorCheckBox.IsChecked == true ? "так" : "ні";
            Room.HasBalcony = BalconyCheckBox.IsChecked == true ? "так" : "ні";
            Room.HasAirConditioner = AirConditionerCheckBox.IsChecked == true ? "так" : "ні";
            Room.RoomType = ((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString();
            Room.BedCount = ((ComboBoxItem)NumberOfBedsSlider.SelectedItem).Content.ToString();

            Reserv.Number = int.Parse(NumberTextBox.Text);
            Reserv.Type = ((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString();
            this.DialogResult = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NumberTextBox.Text = string.Empty;
            PriceTextBox.Text = string.Empty;
            NumberOfRoomsSlider.SelectedIndex = 0;
            FloorNumberTextBox.SelectedIndex = 0;
            TVCheckBox.IsChecked = false;
            RefrigeratorCheckBox.IsChecked = false;
            BalconyCheckBox.IsChecked = false;
            AirConditionerCheckBox.IsChecked = false;
            TypeComboBox.SelectedIndex = 0;
            NumberOfBedsSlider.SelectedIndex = 0;
        }

    }
}
