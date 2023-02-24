/***********************************************************************
 * Module:  LaboratoryReferral.cs
 * Purpose: Definition of the Class Model.LaboratoryReferral
 ***********************************************************************/

using System;

namespace Model.Patient
{
   public class LaboratoryReferral : Referral
   {
      public String RequiredTests { get; set; }
   
   }
}