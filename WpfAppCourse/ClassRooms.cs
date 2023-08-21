using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCourse
{
    public class ClassRooms : INotifyPropertyChanged
    {
        private int number;
        private int floor;
        private string price;
        private string roomCount;
        private string roomType;
        private string bedCount;
        private string hasTV;
        private string hasRefrigerator;
        private string hasBalcony;
        private string hasAirConditioner;

        [Key]
        public int NumberID { get; set; }

        public string HasTV
        {
            get { return hasTV; }
            set
            {
                hasTV = value;
                OnPropertyChanged("HasTV");
            }
        }
        public string HasRefrigerator
        {
            get { return hasRefrigerator; }
            set
            {
                hasRefrigerator = value;
                OnPropertyChanged("HasRefrigerator");
            }
        }

        public string HasBalcony
        {
            get { return hasBalcony; }
            set
            {
                hasBalcony = value;
                OnPropertyChanged("HasBalcony");
            }
        }

        public string HasAirConditioner
        {
            get { return hasAirConditioner; }
            set
            {
                hasAirConditioner = value;
                OnPropertyChanged("HasAirConditioner");
            }
        }

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        public int Floor
        {
            get { return floor; }
            set
            {
                floor = value;
                OnPropertyChanged("Floor");
            }
        }

        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string RoomCount
        {
            get { return roomCount; }
            set
            {
                roomCount = value;
                OnPropertyChanged("RoomCount");
            }
        }

        public string RoomType
        {
            get { return roomType; }
            set
            {
                roomType = value;
                OnPropertyChanged("RoomType");
            }
        }

        public string BedCount
        {
            get { return bedCount; }
            set
            {
                bedCount = value;
                OnPropertyChanged("BedCount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
