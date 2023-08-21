using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для AddReceptionWindow.xaml
    /// </summary>
    public partial class AddReceptionWindow : Window
    {

        public ClassReceptions Reception { get; set; }

        public AddReceptionWindow(ClassReceptions reception)
        {
            InitializeComponent();
            Reception = reception;
            this.DataContext = Reception;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Reception.RecName = NameTextBox.Text;
            Reception.RecSurname = SurnameTextBox.Text;
            Reception.RecPatronimic = PatronymicTextBox.Text;
            Reception.RecPasportId = PassportIdTextBox.Text;
            Reception.RecDateOfBirth = DateOfBirthPicker.SelectedDate.ToString(); 
            Reception.RecCountry = CountryTextBox.Text;
            Reception.RecCity = CityTextBox.Text;
            Reception.RecAddres = AddressTextBox.Text;
            Reception.RecEnglish = EngCheckBox.IsChecked == true ? "так" : "ні";
            Reception.RecUkrainian = UkrCheckBox.IsChecked == true ? "так" : "ні";
            Reception.RecExperience = ExperienceTextBox.Text;
            Reception.RecPrWork = PrWorkTextBox.Text;
            Reception.RecDate = DateOfStartPicker.SelectedDate.ToString();
            Reception.RecLogin = LoginTextBox.Text;
            Reception.RecJobTitle = JobTitleTextBox.Text;

            this.DialogResult = true;
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
            DateOfStartPicker.SelectedDate = null;
            PrWorkTextBox.Text = string.Empty;
            ExperienceTextBox.Text = string.Empty;
            LoginTextBox.Text = string.Empty;
            JobTitleTextBox.Text = string.Empty;
            EngCheckBox.IsChecked = false;
            UkrCheckBox.IsChecked = false;
        }
    }
}

