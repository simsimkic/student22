/***********************************************************************
 * Module:  SpecialistReferral.cs
 * Purpose: Definition of the Class Model.SpecialistReferral
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Model.Patient
{
   public class SpecialistReferral : Referral
   {
      public Examination examination { get; set; }

    }
}