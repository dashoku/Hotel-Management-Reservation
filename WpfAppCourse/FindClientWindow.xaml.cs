using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppCourse
{
    public partial class FindClientWindow : Window
    {
      
        public FindClientWindow()
        {
            InitializeComponent();
        }

        public string NameFilter { get { return NameTextBox.Text; } }
        public string SurnameFilter { get { return SurnameTextBox.Text; } }
        public string PatronymicFilter { get { return PatronymicTextBox.Text; } }
        public string PassportIdFilter { get { return PassportIdTextBox.Text; } }
        public string CountryFilter { get { return CountryTextBox.Text; } }
        public string CityFilter { get { return CityTextBox.Text; } }
        public string AddressFilter { get { return AddressTextBox.Text; } }
        public string WorkStudyFilter { get { return WorkStudyTextBox.Text; } }
        public bool IsVipFilter { get { return VIPClientCheckBox.IsChecked ?? false; } }
        public string NotesFilter { get { return NotesTextBox.Text; } }



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
