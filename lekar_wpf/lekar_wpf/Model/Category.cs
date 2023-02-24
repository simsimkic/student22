using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.Model
{
    public class Category : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != null && !name.Equals(value))
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
                else
                {
                    name = value;
                }
            }
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Category(string name)
        {
            this.Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
