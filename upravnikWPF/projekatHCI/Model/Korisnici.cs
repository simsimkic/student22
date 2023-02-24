using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatHCI.Model
{
    public class Korisnici : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        private string _lozinka;

        public string Lozinka
        {
            get
            {
                return _lozinka;
            }
            set
            {
                if (value != _lozinka)
                {
                    _lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }
    }
}
