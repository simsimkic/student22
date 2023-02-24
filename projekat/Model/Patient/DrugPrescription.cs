/***********************************************************************
 * Module:  DrugPrescription.cs
 * Purpose: Definition of the Class Model.DrugPrescription
 ***********************************************************************/

using System;

namespace Model.Patient
{
   public class DrugPrescription : MedicalDocument
   {
      public String DrugCode { get; set; }
      public String DrugName { get; set; }
      public Dose Dose { get; set; }
      public String Comment { get; set; }
   
   }
}