using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatHCI.Model
{
   public class Lek : INotifyPropertyChanged
    {
        private string _ime;
        
        private int _kolicina;
        private string _sastav;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

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

        public int Kolicina
        {
            get
            {
                return _kolicina;
            }
            set
            {
                if (value != _kolicina)
                {
                    _kolicina = value;
                    OnPropertyChanged("Kolicina");
                }
            }
        }

        public string Sastav
        {
            get
            {
                return _sastav;
            }
            set
            {
                if (value != _sastav)
                {
                    _sastav = value;
                    OnPropertyChanged("Sastav");
                }
            }
        }

       




       

    }
}
