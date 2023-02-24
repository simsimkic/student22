/***********************************************************************
 * Module:  Specialization.cs
 * Purpose: Definition of the Class Model.Doctor.Specialization
 ***********************************************************************/

using System;

namespace Model.Doctor
{
   public class Specialization
   {
      public Model.Users.DoctorSpecialist[] doctorSpecialist;
   
        private int id;
        private String name;

        public Specialization(int id, String name)
        {
            this.id = id;
            this.name = Name;

        }
        public int Id { get => id; set => id = value; }
        public String Name { get => name; set => name = value; }


    }
}