using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp16;

namespace WpfAppCourse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        private string userRole;

        public MainWindow(string role)
        {
            InitializeComponent();

            userRole = role;

            DataContext = this;
            db = new ApplicationContext();
            db.Reception.Load();
            this.DataContext = db.Reception.Local;
            recepList.ItemsSource = db.Reception.Local;

            db.Reservation.Load();
            this.DataContext = db.Reservation.Local;

            db.Room.Load();
            this.DataContext = db.Room.Local;
            roomList.ItemsSource = db.Room.Local;

            db.Client.Load();
            this.DataContext = db.Client.Local;
            clientList.ItemsSource = db.Client.Local;
            vipclientList.ItemsSource = db.Client.Local;
            Loaded += MainWindow_Load;
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl tabControl)
            {
                if (tabControl.SelectedItem == vipTabItem)
                {
                    CollectionViewSource.GetDefaultView(vipclientList.ItemsSource).Filter = IsVIPFilter;
                }
                else if (tabControl.SelectedItem == allTabItem)
                {
                    if (vipclientList.ItemsSource != null)
                    {
                        CollectionViewSource.GetDefaultView(vipclientList.ItemsSource).Filter = null;
                    }

                }
            }
        }

        private bool IsVIPFilter(object item)
        {
            ClassClients client = item as ClassClients;
            if (client != null)
            {
                if (client.ClIsVIP == "так" && clientTabControl.SelectedItem == vipTabItem)
                {
                    return true;
                }
                else if (clientTabControl.SelectedItem == allTabItem)
                {
                    return true;
                }
            }
            return false;
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (userRole == "Receptionist")
            {
                AddClientButton.Visibility = Visibility.Visible;
                receptionTabItem.Visibility = Visibility.Collapsed;
                MainTabControl.Visibility = Visibility.Visible;
                AddNumberButton.Visibility = Visibility.Collapsed;
                DeleteNumberButton.Visibility= Visibility.Collapsed;
                ReceptionistGrid.Visibility = Visibility.Collapsed;
            }
            else if (userRole == "Admin")
            {
                AddClientButton.Visibility = Visibility.Visible;
                receptionTabItem.Visibility = Visibility.Visible;
                MainTabControl.Visibility = Visibility.Visible;
                AddNumberButton.Visibility = Visibility.Visible;
            }
            CollectionViewSource.GetDefaultView(vipclientList.ItemsSource).Filter = IsVIPFilter;
        }

        private FindClientWindow findCientWindow;
        private void UserFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            var find = new FindClientWindow();

            if (find.ShowDialog() == true) 
            {
                var name = find.NameFilter;
                var surname = find.SurnameFilter;
                var patronymic = find.PatronymicFilter;
                var passportId = find.PassportIdFilter;
                var country = find.CountryFilter;
                var city = find.CityFilter;
                var address = find.AddressFilter;
                var workStudy = find.WorkStudyFilter;
                var vipClient = find.IsVipFilter;
                var notes = find.NotesFilter;

                // perform the filtering
                var filteredClients = db.Client.Local;

                if (!string.IsNullOrEmpty(name))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClName.ToLower().Contains(name.ToLower())));
                }

                if (!string.IsNullOrEmpty(surname))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClSurname.ToLower().Contains(surname.ToLower())));
                }

                if (!string.IsNullOrEmpty(patronymic))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClPatronimic.ToLower().Contains(patronymic.ToLower())));
                }

                if (!string.IsNullOrEmpty(passportId))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClPasportId.ToLower().Contains(passportId.ToLower())));
                }

                if (!string.IsNullOrEmpty(country))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClCountry.ToLower().Contains(country.ToLower())));
                }

                if (!string.IsNullOrEmpty(city))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClCity.ToLower().Contains(city.ToLower())));
                }

                if (!string.IsNullOrEmpty(address))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClAddres.ToLower().Contains(address.ToLower())));
                }


                if (!string.IsNullOrEmpty(workStudy))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClWorkStudy.ToLower().Contains(workStudy.ToLower())));
                }

                if (vipClient)
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClIsVIP == "True"));
                }

                if (!string.IsNullOrEmpty(notes))
                {
                    filteredClients = new ObservableCollection<ClassClients>(filteredClients.Where(c => c.ClNotes.ToLower().Contains(notes.ToLower())));
                }
                clientList.ItemsSource = filteredClients.OrderBy(c => c.ClName).ToList();
            }
        }

        private FindNumberWindow findNumberWindow;
        private void NumbFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            var find = new FindNumberWindow();
            if (find.ShowDialog() == true)
            {
                var number = find.NumberFilter;
                var minPrice = find.MinPriceFilter;
                var maxPrice = find.MaxPriceFilter;
                var numberOfRooms = find.NumberOfRoomsFilter;
                var floorNumber = find.FloorNumberFilter;
                var hasTV = find.HasTVFilter;
                var hasRefrigerator = find.HasRefrigeratorFilter;
                var hasBalcony = find.HasBalconyFilter;
                var hasAirConditioner = find.HasAirConditionerFilter;
                var roomType = find.RoomTypeFilter;
                var numberOfBeds = find.NumberOfBedsFilter;

                var filteredNumbers = db.Room.Local;
                if (!string.IsNullOrEmpty(number))
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.Number.Equals(number)));
                }

                if (!string.IsNullOrEmpty(minPrice))
                {
                    int minPriceValue = int.Parse(minPrice);
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => int.Parse(n.Price) >= minPriceValue));
                }

                if (!string.IsNullOrEmpty(maxPrice))
                {
                    int maxPriceValue = int.Parse(maxPrice);
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => int.Parse(n.Price) <= maxPriceValue));
                }

                if (!string.IsNullOrEmpty(numberOfRooms))
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.RoomCount == numberOfRooms));
                }

                if (!string.IsNullOrEmpty(floorNumber))
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.Floor.Equals(floorNumber)));
                }

                if (hasTV)
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.HasTV == "True"));
                }

                if (hasRefrigerator)
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.HasRefrigerator == "True"));
                }

                if (hasBalcony)
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.HasBalcony == "True"));
                }

                if (hasAirConditioner)
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.HasAirConditioner == "True"));
                }

                if (!string.IsNullOrEmpty(roomType))
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.RoomType == roomType));
                }

                if (!string.IsNullOrEmpty(numberOfBeds))
                {
                    filteredNumbers = new ObservableCollection<ClassRooms>(filteredNumbers.Where(n => n.BedCount == numberOfBeds));
                }
                roomList.ItemsSource = filteredNumbers.OrderBy(r => r.Number).ToList();


            }
        }

        private FindReceptionWindow findReceptionWindow;
        private void RecepFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            var find = new FindReceptionWindow();
            if (find.ShowDialog() == true)
            {
                var name = find.NameFilter;
                var surname = find.SurnameFilter;
                var patronymic = find.PatronymicFilter;
                var passportId = find.PassportIdFilter;
                var dateOfBirth = find.DateOfBirthFilter;
                var country = find.CountryFilter;
                var city = find.CityFilter;
                var address = find.AddressFilter;
                var english = find.EnglishFilter;
                var ukraine = find.UkraineFilter;
                var dateOfStart = find.DateOfStartFilter;
                var previousWork = find.PreviousWorkFilter;
                var experience = find.ExperienceFilter;
                var login = find.LoginFilter;
                var jobTitle = find.JobTitleFilter;

                var filteredReceptions = db.Reception.Local;

                if (!string.IsNullOrEmpty(name))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecName.ToLower().Contains(name.ToLower())));
                }

                if (!string.IsNullOrEmpty(surname))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecSurname.ToLower().Contains(surname.ToLower())));
                }

                if (!string.IsNullOrEmpty(patronymic))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecPatronimic.ToLower().Contains(patronymic.ToLower())));
                }

                if (!string.IsNullOrEmpty(passportId))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecPasportId.ToLower().Contains(passportId.ToLower())));
                }

                if (!string.IsNullOrEmpty(country))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecCountry.ToLower().Contains(country.ToLower())));
                }

                if (!string.IsNullOrEmpty(city))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecCity.ToLower().Contains(city.ToLower())));
                }

                if (!string.IsNullOrEmpty(address))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecAddres.ToLower().Contains(address.ToLower())));
                }

                if (english)
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecEnglish == "True"));

                }

                if (ukraine)
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecUkrainian == "True"));
                }

                if (!string.IsNullOrEmpty(previousWork))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecPrWork.ToLower().Contains(previousWork.ToLower())));
                }

                if (!string.IsNullOrEmpty(experience))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecExperience.ToLower().Contains(experience.ToLower())));
                }

                if (!string.IsNullOrEmpty(login))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecLogin.ToLower().Contains(login.ToLower())));
                }

                if (!string.IsNullOrEmpty(jobTitle))
                {
                    filteredReceptions = new ObservableCollection<ClassReceptions>(filteredReceptions.Where(r => r.RecJobTitle.ToLower().Contains(jobTitle.ToLower())));
                }

                recepList.ItemsSource = filteredReceptions.OrderBy(r => r.RecName).ToList();
            }
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClassClients client = new ClassClients(); 

            AddClientWindow addClientWindow = new AddClientWindow(client);
            if (addClientWindow.ShowDialog() == true)
            {
                client = addClientWindow.Client; 

                db.Client.Add(client);
                db.SaveChanges();

                clientList.ItemsSource = db.Client.Local;
                clientList.Items.Refresh();
            }
        }


        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedItem is ClassClients selectedClient)
            {
                MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього клієнта?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.Client.Remove(selectedClient); 
                    db.SaveChanges(); 
                    MessageBox.Show("Клієнтa успішно видалено.", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Жодного клієнта не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddNumberButton_Click(object sender, RoutedEventArgs e)
        {
            ClassRooms number = new ClassRooms();

            AddNumberWindow addNumberWindow = new AddNumberWindow(number);
            if (addNumberWindow.ShowDialog() == true)
            {
                number = addNumberWindow.Room;

                db.Room.Add(number);
                db.SaveChanges();
            }
        }

        private void DeleteNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomList.SelectedItem is ClassRooms selectedRoom)
            {
                MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете видалити цей номер?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.Room.Remove(selectedRoom); 
                    db.SaveChanges(); 
                    MessageBox.Show("Кімнату успішно видалено.", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Жодного номера не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddReceptionistButton_Click(object sender, RoutedEventArgs e)
        {
            ClassReceptions receptionist = new ClassReceptions();

            AddReceptionWindow addReceptionistWindow = new AddReceptionWindow(receptionist);
            if (addReceptionistWindow.ShowDialog() == true)
            {
                receptionist = addReceptionistWindow.Reception;

                db.Reception.Add(receptionist);
                db.SaveChanges();
            }
        }

        private void DeleteReceptionistButton_Click(object sender, RoutedEventArgs e)
        {
            if (recepList.SelectedItem is ClassReceptions selectedReception)
            {
                MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього портьє?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.Reception.Remove(selectedReception); 
                    db.SaveChanges(); 
                    MessageBox.Show("Портьє успішно видалено.", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Жодного портьє не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedItem == null) return;
            ClassClients client = clientList.SelectedItem as ClassClients;
            AddClientWindow clientWindow = new AddClientWindow(new ClassClients
            {
                ClientID = client.ClientID,
                ClName = client.ClName,
                ClSurname = client.ClSurname,
                ClPatronimic = client.ClPatronimic,
                ClPasportId = client.ClPasportId,
                ClDateOfBirth = client.ClDateOfBirth,
                ClCountry = client.ClCountry,
                ClCity = client.ClCity,
                ClAddres = client.ClAddres,
                ClRegistrationDate = client.ClRegistrationDate,
                ClDepartureDate = client.ClDepartureDate,
                ClWorkStudy = client.ClWorkStudy,
                ClRoomfree = client.ClRoomfree,
                ClCashPayment = client.ClCashPayment,
                ClReceiptNumber = client.ClReceiptNumber,
                ClIsVIP = client.ClIsVIP,
                ClNotes = client.ClNotes,

            });
            if (clientWindow.ShowDialog() == true)
            {
                client = db.Client.Find(clientWindow.Client.ClientID);
                if (client != null)
                {
                    client.ClientID = clientWindow.Client.ClientID;
                    client.ClName = clientWindow.Client.ClName;
                    client.ClSurname = clientWindow.Client.ClSurname;
                    client.ClPatronimic = clientWindow.Client.ClPatronimic;
                    client.ClPasportId = clientWindow.Client.ClPasportId;
                    client.ClDateOfBirth = clientWindow.Client.ClDateOfBirth;
                    client.ClCountry = clientWindow.Client.ClCountry;
                    client.ClCity = clientWindow.Client.ClCity;
                    client.ClAddres = clientWindow.Client.ClAddres;
                    client.ClRegistrationDate = clientWindow.Client.ClRegistrationDate;
                    client.ClDepartureDate = clientWindow.Client.ClDepartureDate;
                    client.ClWorkStudy = clientWindow.Client.ClWorkStudy;
                    client.ClRoomfree = clientWindow.Client.ClRoomfree;
                    client.ClCashPayment = clientWindow.Client.ClCashPayment;
                    client.ClReceiptNumber = clientWindow.Client.ClReceiptNumber;
                    client.ClIsVIP = clientWindow.Client.ClIsVIP;
                    client.ClNotes = clientWindow.Client.ClNotes;
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();

                    clientList.ItemsSource = db.Client.Local;
                    clientList.Items.Refresh();
                }
            }
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            clientList.ItemsSource = db.Client.Local.OrderBy(c => c.ClName).ToList();
        }

        private void ClearFiltersRecButton_Click(object sender, RoutedEventArgs e)
        {
            recepList.ItemsSource = db.Reception.Local.OrderBy(c => c.RecName).ToList();
        }

        private void ClearFiltersNumbButton_Click(object sender, RoutedEventArgs e)
        {
            roomList.ItemsSource = db.Room.Local.OrderBy(c => c.Number).ToList();
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені, що бажаєте вийти?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) { 
            LogonWindow loginWindow = new LogonWindow();
            loginWindow.Show();
            this.Close();
            }
        }

        private void EditReceptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (recepList.SelectedItem == null) return;
            ClassReceptions reception = recepList.SelectedItem as ClassReceptions;
            AddReceptionWindow receptionWindow = new AddReceptionWindow(new ClassReceptions
            {
                WorkerID = reception.WorkerID,
                RecName = reception.RecName,
                RecSurname = reception.RecSurname,
                RecPatronimic = reception.RecPatronimic,
                RecPasportId = reception.RecPasportId,
                RecDateOfBirth = reception.RecDateOfBirth,
                RecCountry = reception.RecCountry,
                RecCity = reception.RecCity,
                RecAddres = reception.RecAddres,
                RecEnglish = reception.RecEnglish,
                RecUkrainian = reception.RecUkrainian,
                RecExperience = reception.RecExperience,
                RecPrWork = reception.RecPrWork,
                RecDate = reception.RecDate,
                RecLogin = reception.RecLogin,
                RecJobTitle = reception.RecJobTitle,

            });
            if (receptionWindow.ShowDialog() == true)
            {
                reception = db.Reception.Find(receptionWindow.Reception.WorkerID);
                if (reception != null)
                {
                    reception.WorkerID = receptionWindow.Reception.WorkerID;
                    reception.RecName = receptionWindow.Reception.RecName;
                    reception.RecSurname = receptionWindow.Reception.RecSurname;
                    reception.RecPatronimic = receptionWindow.Reception.RecPatronimic;
                    reception.RecPasportId = receptionWindow.Reception.RecPasportId;
                    reception.RecDateOfBirth = receptionWindow.Reception.RecDateOfBirth;
                    reception.RecCountry = receptionWindow.Reception.RecCountry;
                    reception.RecCity = receptionWindow.Reception.RecCity;
                    reception.RecAddres = receptionWindow.Reception.RecAddres;
                    reception.RecEnglish = receptionWindow.Reception.RecEnglish;
                    reception.RecUkrainian = receptionWindow.Reception.RecUkrainian;
                    reception.RecExperience = receptionWindow.Reception.RecExperience;
                    reception.RecPrWork = receptionWindow.Reception.RecPrWork;
                    reception.RecDate = receptionWindow.Reception.RecDate;
                    reception.RecLogin = receptionWindow.Reception.RecLogin;
                    reception.RecJobTitle = receptionWindow.Reception.RecJobTitle;
                    db.Entry(reception).State = EntityState.Modified;
                    db.SaveChanges();

                    recepList.ItemsSource = db.Reception.Local;
                    recepList.Items.Refresh();
                }
            }

        }

        private void EditNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomList.SelectedItem == null) return;
            ClassRooms number = roomList.SelectedItem as ClassRooms;
            AddNumberWindow numberWindow = new AddNumberWindow(new ClassRooms
            {
                NumberID = number.NumberID,
                HasRefrigerator = number.HasRefrigerator,
                HasBalcony = number.HasBalcony,
                HasAirConditioner = number.HasAirConditioner,
                Number = number.Number,
                Floor = number.Floor,
                Price = number.Price,
                RoomCount = number.RoomCount,
                RoomType = number.RoomType,
                BedCount = number.BedCount,

            });
            if (numberWindow.ShowDialog() == true)
            {
                number = db.Room.Find(numberWindow.Room.NumberID);
                if (number != null)
                {
                    number.NumberID = numberWindow.Room.NumberID;
                    number.HasRefrigerator = numberWindow.Room.HasRefrigerator;
                    number.HasBalcony = numberWindow.Room.HasBalcony;
                    number.HasAirConditioner = numberWindow.Room.HasAirConditioner;
                    number.Number = numberWindow.Room.Number;
                    number.Floor = numberWindow.Room.Floor;
                    number.Price = numberWindow.Room.Price;
                    number.RoomCount = numberWindow.Room.RoomCount;
                    number.RoomType = numberWindow.Room.RoomType;
                    number.BedCount = numberWindow.Room.BedCount;
                    db.Entry(number).State = EntityState.Modified;
                    db.SaveChanges();

                    roomList.ItemsSource = db.Room.Local;
                    roomList.Items.Refresh();
                }
            }

        }
    }

}



