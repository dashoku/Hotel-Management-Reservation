using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfAppCourse
{
    public class ClassClients : INotifyPropertyChanged
    {
        public static List<ClassClients> clients = new List<ClassClients>();

        public string name;
        public string surname;
        public string patronimic;
        public string pasportid;
        public string birth;
        public string country;
        public string city;
        public string addres;
        public string dateregistr;
        public string departuredate;
        public string workstudy;
        public string roomfree;
        public string cashpayment;
        public string receiptnumber;
        public string isvip;
        public string notes;

        [Key]
        public int ClientID { get; set; }

        public string ClName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyCanged("Name");
            }
        }

        public string ClSurname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyCanged("Surname");
            }
        }
        public string ClPatronimic
        {
            get { return patronimic; }
            set
            {
                patronimic = value;
                OnPropertyCanged("Patronimic");
            }
        }
        public string ClPasportId
        {
            get { return pasportid; }
            set
            {
                pasportid = value;
                OnPropertyCanged("PasportId");
            }
        }
        public string ClDateOfBirth
        {
            get { return birth; }
            set
            {
                birth = value;
                OnPropertyCanged("DateOfBirth");
            }
        }
        public string ClCountry
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyCanged("Country");
            }
        }
        public string ClCity
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyCanged("City");
            }
        }
        public string ClAddres
        {
            get { return addres; }
            set
            {
                addres = value;
                OnPropertyCanged("Addres");
            }
        }
        public string ClRegistrationDate
        {
            get { return dateregistr; }
            set
            {
                dateregistr = value;
                OnPropertyCanged("Dateregistr");
            }
        }
        public string ClDepartureDate
        {
            get { return departuredate; }
            set
            {
                departuredate = value;
                OnPropertyCanged("DepartureDate");
            }
        }
        public string ClWorkStudy
        {
            get { return workstudy; }
            set
            {
                workstudy = value;
                OnPropertyCanged("WorkStudy");
            }
        }
        public string ClRoomfree
        {
            get { return roomfree; }
            set
            {
                roomfree = value;
                OnPropertyCanged("Roomfree");
            }
        }
        public string ClCashPayment
        {
            get { return cashpayment; }
            set
            {
                cashpayment = value;
                OnPropertyCanged("CashPayment");
            }
        }
        public string ClReceiptNumber
        {
            get { return receiptnumber; }
            set
            {
                receiptnumber = value;
                OnPropertyCanged("ReceiptNumber");
            }
        }
        public string ClIsVIP
        {
            get { return isvip; }
            set
            {
                isvip = value;
                OnPropertyCanged("IsVIP");
            }
        }
        public string ClNotes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyCanged("Notes");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyCanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }


    }
}

