using Model.Util;
using ProjekatKlinika.Repository.Abstract;
using System;

namespace Model.Users
{
    public class Manager : User, IIdentifiable<long>
    {
        private long idNumber;
        public Manager() : base()
        {

        }
        public Manager(int idNumber, string name, string surname, string phoneNumber, string email, Address address, string jmbg, DateTime birthDate, string username, string password)
           : base(name, surname, phoneNumber, email, address, jmbg, birthDate, username, password)
        {
            
            this.idNumber = idNumber;
        }

        public long IdNumber { get => idNumber; set => idNumber = value; }

        public long GetId()
        {

            return idNumber;


        }

        public void SetId(long id)
        {

            idNumber = id;

            

        }
    }
}