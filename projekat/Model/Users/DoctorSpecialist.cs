/***********************************************************************
 * Module:  DoctorSpecialist.cs
 * Purpose: Definition of the Class Model.Users.DoctorSpecialist
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Model.Users
{
   public class DoctorSpecialist : Doctor
   {
        public DoctorSpecialist() : base()
        {

        }
        private Specialization specialization;
      
        public Specialization Specialization { get; set; }
   
   }
}