/***********************************************************************
 * Module:  Patient.cs
 * Purpose: Definition of the Class Model.Users.Patient
 ***********************************************************************/

using Model.Doctor;
using Model.Patient;
using Model.Util;
using ProjekatKlinika.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model.Users
{
   public class Patient : User, IIdentifiable<long>
   {
        public MedicalRecord medicalRecord;
   
        private int idNumber;
        public bool isGuest { get; set; } = false;
        public Gender gender { get; set; }
        public String parentName { get; set; }

        public Patient() : base()
        {
        }

        public Patient(Patient patient) : base(patient.name, patient.surname, patient.phoneNumber, patient.email, patient.address, patient.jmbg, patient.birthDate, patient.username, patient.password)
        {
            this.medicalRecord = patient.medicalRecord;
            this.IdNumber = patient.IdNumber;
            this.gender = patient.gender;
            this.parentName = patient.parentName;
        }

        public Patient(MedicalRecord medicalRecord, int idNumber, string name, string surname, string phoneNumber, string email, Address address, string jmbg, DateTime birthDate, string username, string password)
            : base(name, surname, phoneNumber, email, address, jmbg, birthDate, username, password)
        {
            this.medicalRecord = medicalRecord;
            this.idNumber = idNumber;
        }

        public long IdNumber { get => idNumber; set => idNumber = (int)value; }

        public long GetId()
        {
            return idNumber;
        }

        public void SetId(long id)
        {
            idNumber = (int)id;
        }

        public List<Report> GetReports()
        {
            return medicalRecord.reports;
        }

        public List<SpecialistReferral> GetSpecialistReferrals()
        {
            return medicalRecord.specialistReferrals;
        }

        public List<LaboratoryReferral> GetLaboratoryReferrals()
        {
            return medicalRecord.laboratoryReferrals;
        }

        public List<HospitalizationReferral> GetHospitalizationReferrals()
        {
            return medicalRecord.hospitalizationReferrals;
        }

        public List<DrugPrescription> GetDrugPrescriptions()
        {
            return medicalRecord.drugPerscriptions;
        }
    }
}