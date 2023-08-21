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
    /// Логика взаимодействия для FindReceptionWindow.xaml
    /// </summary>
    public partial class FindReceptionWindow : Window
    {
        public FindReceptionWindow()
        {
            InitializeComponent();
        }
        public string NameFilter { get { return NameTextBox.Text; } }
        public string SurnameFilter { get { return SurnameTextBox.Text; } }
        public string PatronymicFilter { get { return PatronymicTextBox.Text; } }
        public string PassportIdFilter { get { return PassportIdTextBox.Text; } }
        public DateTime DateOfBirthFilter { get { return DateOfBirthPicker.SelectedDate ?? DateTime.MinValue; } }
        public string CountryFilter { get { return CountryTextBox.Text; } }
        public string CityFilter { get { return CityTextBox.Text; } }
        public string AddressFilter { get { return AddressTextBox.Text; } }
        public bool EnglishFilter { get { return EngCheckBox.IsChecked ?? false; } }
        public bool UkraineFilter { get { return UkrCheckBox.IsChecked ?? false; } }
        public DateTime DateOfStartFilter { get { return DateOfStartPicker.SelectedDate ?? DateTime.MinValue; } }
        public string PreviousWorkFilter { get { return PrWorkTextBox.Text; } }
        public string ExperienceFilter { get { return ExperienceTextBox.Text; } }
        public string LoginFilter { get { return LoginTextBox.Text; } }
        public string JobTitleFilter { get { return JobTitleTextBox.Text; } }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
