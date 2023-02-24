/***********************************************************************
 * Module:  Examination.cs
 * Purpose: Definition of the Class Model.Examination
 ***********************************************************************/

using Model.Manager;
using Model.Patient;
using Model.Util;
using System;

namespace Model.Doctor
{
   public class Examination : Appointment
   {
      public Model.Patient.SpecialistReferral specialistReferral;

        public Examination(Room room, Users.Doctor doctor, Users.Patient patient, Duration duration, SpecialistReferral specialistReferral) : base(room, doctor, patient, duration)
        {
            this.specialistReferral = specialistReferral;
        }
    }
}