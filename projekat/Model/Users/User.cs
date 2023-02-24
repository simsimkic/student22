/***********************************************************************
 * Module:  User.cs
 * Purpose: Definition of the Class Model.Users.User
 ***********************************************************************/

using Model.Util;
using System;
using System.ComponentModel;

namespace Model.Users
{
   public class User : INotifyPropertyChanged
   {
      public String name { get; set; }
      public String surname { get; set; }
      public String phoneNumber { get; set; }
      public String email { get; set; }
      public Model.Util.Address address { get; set; }
      public String jmbg { get; set; }
      public DateTime birthDate { get; set; }
      public String username { get; set; }
      public String password { get; set; }

        public User() { }
        public User(string name, string surname, string phoneNumber, string email, Address address, string jmbg, DateTime birthDate, string username, string password)
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.address = address;
            this.jmbg = jmbg;
            this.birthDate = birthDate;
            this.username = username;
            this.password = password;
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