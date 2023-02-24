using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekretar_WPF_Project.TestModel
{

    public class Doctor : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyRaised("Name");
                //OnPropertyRaised("Fullname");
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyRaised("Surname");
                //OnPropertyRaised("Fullname");
            }
        }
        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                surname = specialization;
                OnPropertyRaised("Specialization");
            }
        }

        /*        private string fullname;
                public string Fullname
                {
                    get
                    {
                        return name + " " + surname; ;
                    }
                    set
                    {
                        fullname = value;
                        OnPropertyRaised("Fullname");
                    }
                }*/

        private int licensenumber;
        public int Licensenumber
        {
            get
            {
                return licensenumber;
            }
            set
            {
                licensenumber = value;
                OnPropertyRaised("Licensenumber");
            }
        }


        public Doctor(int licensenumber, string name, string surname , string spec)
        {
            this.licensenumber = licensenumber;
            this.specialization = spec;
            this.name = name;
            this.surname = surname;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
