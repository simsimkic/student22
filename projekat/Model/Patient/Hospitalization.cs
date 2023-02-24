/***********************************************************************
 * Module:  Hospitalization.cs
 * Purpose: Definition of the Class Model.Patient.Hospitalization
 ***********************************************************************/

using Model.Manager;
using System;

namespace Model.Patient
{
   public class Hospitalization
   {
      public PatientsRoom patientsRoom;
      public HospitalizationReferral hospitalizationReferral;
      public Model.Users.Patient patient;
   
      private Model.Util.Duration TreatmentPeriod;
   
   }
}