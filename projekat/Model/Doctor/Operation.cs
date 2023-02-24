/***********************************************************************
 * Module:  Operation.cs
 * Purpose: Definition of the Class Model.Operation
 ***********************************************************************/

using Model.Manager;
using Model.Patient;
using Model.Util;
using System;

namespace Model.Doctor
{
    public class Operation : Appointment
   {
      public Model.Patient.Hospitalization hospitalization;
        
        public Operation(Room room, Users.Doctor doctor, Users.Patient patient, Duration duration, Hospitalization hospitalization) : base(room, doctor, patient, duration)
        {
            this.hospitalization = hospitalization;
        }

    }
}