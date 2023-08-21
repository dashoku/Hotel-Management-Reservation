using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCourse
{
    public class ClassReceptions : INotifyPropertyChanged
    {
        public string name;
        public string surname;
        public string patronimic;
        public string pasportid;
        public string birth;
        public string country;
        public string city;
        public string addres;
        public string english;
        public string ukrainian;
        public string experience;
        public string prevwork;
        public string date;
        public string login;
        public string password;
        public string jobtitle;

        [Key]

        public int WorkerID { get; set; }

        public string RecName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyCanged("Name");
            }
        }

        public string RecSurname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyCanged("Surname");
            }
        }
        public string RecPatronimic
        {
            get { return patronimic; }
            set
            {
                patronimic = value;
                OnPropertyCanged("Patronimic");
            }
        }
        public string RecPasportId
        {
            get { return pasportid; }
            set
            {
                pasportid = value;
                OnPropertyCanged("PasportId");
            }
        }
        public string RecDateOfBirth
        {
            get { return birth; }
            set
            {
                birth = value;
                OnPropertyCanged("DateOfBirth");
            }
        }
        public string RecCountry
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyCanged("Country");
            }
        }
        public string RecCity
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyCanged("City");
            }
        }
        public string RecAddres
        {
            get { return addres; }
            set
            {
                addres = value;
                OnPropertyCanged("Addres");
            }
        }
        public string RecEnglish
        {
            get { return english; }
            set
            {
                english = value;
                OnPropertyCanged("English");
            }
        }

        public string RecUkrainian
        {
            get { return ukrainian; }
            set
            {
                ukrainian = value;
                OnPropertyCanged("Ukrainian");
            }
        }

        public string RecExperience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyCanged("Experience");
            }
        }
        public string RecPrWork
        {
            get { return prevwork; }
            set
            {
                prevwork = value;
                OnPropertyCanged("PrevWork");
            }
        }
        public string RecDate
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyCanged("Date");
            }
        }
        public string RecLogin
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyCanged("Login");
            }
        }

        public string RecJobTitle
        {
            get { return jobtitle; }
            set
            {
                jobtitle = value;
                OnPropertyCanged("JobTitle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyCanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
