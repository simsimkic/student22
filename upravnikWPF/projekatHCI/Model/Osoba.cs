using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatHCI.Model
{
     public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _prezime;
        public string Prezime
        {
            get
            {
                return _prezime;
            }
            set
            {
                if (value != _prezime)
                {
                    _prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }
        private string _jmbg;
        public string Jmbg
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }

        private string _mejl;

        public string Mejl
        {
            get
            {
                return _mejl;
            }
            set
            {
                if (value != _mejl)
                {
                    _mejl = value;
                    OnPropertyChanged("Mejl");
                }
            }
        }
        private string _zanimanje;

        public string Zanimanje
        {
            get
            {
                return _zanimanje;
            }
            set
            {
                if (value != _zanimanje)
                {
                    _zanimanje = value;
                    OnPropertyChanged("Zanimanje");
                }
            }
        }
        private string _specijalizacija;
        public string Specijalizacija
        {
            get
            {
                return _specijalizacija;
            }
            set
            {
                if (value != _specijalizacija)
                {
                    _specijalizacija = value;
                    OnPropertyChanged("Specijalizacija");
                }
            }
        }



    }
}
