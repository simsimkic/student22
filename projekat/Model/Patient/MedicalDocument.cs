/***********************************************************************
 * Module:  MedicalDocument.cs
 * Purpose: Definition of the Class Model.MedicalDocument
 ***********************************************************************/

using System;

namespace Model.Patient
{
   public class MedicalDocument
   {
      public Model.Users.Doctor doctor { get; set; }
      public Diagnosis diagnosis { get; set; }
      public String HospitalName { get; set; }
      private DateTime TimeWhenIssued { get; set; }

    }
}