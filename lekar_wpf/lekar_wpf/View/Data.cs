using lekar_wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.View
{
    public class Data
    {
        public static Doctor gpDoctor { get; set; }
        public static Doctor specialist { get; set; }
        public static Doctor signedIn { get; set; }

        public Data()
        {
            gpDoctor = new Doctor();
            gpDoctor.FullName = "Tamara Rankovic";
            gpDoctor.BirthDate = new DateTime(1998, 11, 29).ToString("dd/MM/yyyy");
            gpDoctor.Address = "Strazilovska 15, Novi Sad";
            gpDoctor.Email = "rankovictamaraa@gmail.com";
            gpDoctor.Jmbg = "2911998777011";
            gpDoctor.Rating = 9.2;
            gpDoctor.Specialization = "Lekar opste prakse";
            gpDoctor.PhoneNumber = "0653371199";
            gpDoctor.Password = "Lozinka1";
            gpDoctor.LicenceNumber = "142385";
            specialist = new Doctor();
            specialist.FullName = "Emina Turkovic";
            specialist.BirthDate = new DateTime(1998, 11, 9).ToString("dd/MM/yyyy");
            specialist.Address = "Alekse Santica 10, Novi Sad";
            specialist.Email = "emina.turkovic@gmail.com";
            specialist.Jmbg = "0911998777012";
            specialist.Rating = 9.5;
            specialist.Specialization = "Specijalista kardiologije";
            specialist.PhoneNumber = "0648268712";
            specialist.Password = "Lozinka2";
            specialist.LicenceNumber = "83516";
        }
    }
}
