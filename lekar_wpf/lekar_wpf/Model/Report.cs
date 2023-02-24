using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.Model
{
    public class Report : INotifyPropertyChanged
    {
        private string date;
        public string Date { 
            get { return date; }
            set { date = value; }
        }

        private string odeljenje;
        public string Odeljenje 
        { 
            get { return odeljenje; } 
            set { odeljenje = value; } 
        }

        private string diagnosis;
        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private string doctor;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
