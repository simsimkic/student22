/***********************************************************************
 * Module:  MedicalRecord.cs
 * Purpose: Definition of the Class Model.MedicalRecord
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Patient
{
   public class MedicalRecord
   {
        public List<HospitalizationReferral> hospitalizationReferrals { get; set; }
        public List<LaboratoryReferral> laboratoryReferrals { get; set; }
        public List<SpecialistReferral> specialistReferrals { get; set; }
        public List<DrugPrescription> drugPerscriptions { get; set; }
        public List<Report> reports { get; set; }
    }
}