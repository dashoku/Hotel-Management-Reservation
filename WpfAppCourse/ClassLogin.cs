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
    public class ClassLogin : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        private string job_title;
        private string password;
        private string email;


        public string JobTitle
        {
            get { return job_title; }
            set
            {
                job_title = value;
                OnPropertyCanged("Job_title");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyCanged("Password");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyCanged("Email");
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
