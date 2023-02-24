using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatHCI.Model
{
    public class Renoviranje : INotifyPropertyChanged
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

        private string _pocetniD;

        public string PocetniD
        {
            get
            {
                return _pocetniD;
            }
            set
            {
                if (value != _pocetniD)
                {
                    _pocetniD = value;
                    OnPropertyChanged("PocetniD");
                }
            }
        }

        private string _krajnjiD;

        public string KrajnjiD
        {
            get
            {
                return _krajnjiD;
            }
            set
            {
                if (value != _krajnjiD)
                {
                    _krajnjiD = value;
                    OnPropertyChanged("KrajnjiD");
                }
            }
        }

    }

}
