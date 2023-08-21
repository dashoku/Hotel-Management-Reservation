using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppCourse
{
    /// <summary>
    /// Логика взаимодействия для FindNumberWindow.xaml
    /// </summary>
    public partial class FindNumberWindow : Window
    {
        public FindNumberWindow()
        {
            InitializeComponent();
        }

        public string NumberFilter { get { return NumberTextBox.Text; } }

        public string MinPriceFilter { get { return MinPriceTextBox.Text; } }
        public string MaxPriceFilter { get { return MaxPriceTextBox.Text;} }
        public string NumberOfRoomsFilter
        {
            get
            {
                if (NumberOfRoomsSlider.SelectedItem != null)
                {
                    return ((ComboBoxItem)NumberOfRoomsSlider.SelectedItem).Content.ToString();
                }
                return string.Empty; 
            }
        }

        public string FloorNumberFilter
        {
            get
            {
                if (FloorNumberTextBox.SelectedItem != null)
                {
                    return ((ComboBoxItem)FloorNumberTextBox.SelectedItem).Content.ToString();
                }
                return string.Empty;
            }
        }

        public bool HasTVFilter  { get { return TVCheckBox.IsChecked ?? false;} }
        public bool HasRefrigeratorFilter { get { return RefrigeratorCheckBox.IsChecked ?? false;} }
        public bool HasBalconyFilter { get { return BalconyCheckBox.IsChecked ?? false;} }
        public bool HasAirConditionerFilter { get { return AirConditionerCheckBox.IsChecked ?? false;} }
        public string RoomTypeFilter
        {
            get
            {
                if (TypeComboBox.SelectedItem != null)
                {
                    return ((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString();
                }
                return string.Empty; 
            }
        }

        public string NumberOfBedsFilter
        {
            get
            {
                if (NumberOfBedsSlider.SelectedItem != null)
                {
                    return ((ComboBoxItem)NumberOfBedsSlider.SelectedItem).Content.ToString();
                }
                return string.Empty; 
            }
        }



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
