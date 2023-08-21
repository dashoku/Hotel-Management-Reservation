using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCourse
{
    public class ClassReservations
    {
        [Key]
      
        public string BookedBy { get; set; }
        public string BookingPeriod { get; set; }

        private int number;
        private string type;
        private bool status;
        private string startdate;
        private string enddate;
        private string name;
        private string surname;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public string BookingStart
        {
            get { return startdate; }
            set
            {
                startdate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public string BookingEnd
        {
            get { return enddate; }
            set
            {
                enddate = value;
                OnPropertyChanged("EndtDate");
            }
        }

        public bool BookingStatus
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
