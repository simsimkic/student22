/***********************************************************************
 * Module:  PatientService.cs
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Model.Patient;
using Model.Users;
using ProjekatKlinika.Repository.Abstract.PatientAbstract;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class PatientService : IService<Patient, long>
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository pRepository)
        {
            this.patientRepository = pRepository;
        }

        public Patient Create(Patient entity) => patientRepository.Create(entity);

        public void Delete(Patient entity) => patientRepository.Delete(entity);

        public Patient Get(long id) => patientRepository.Get(id);

        public System.Collections.Generic.IEnumerable<Patient> GetAll() => patientRepository.GetAll();

        public void Update(Patient entity) => patientRepository.Update(entity);

        public Patient LogIn(String email, String password)
        {
            List<Patient> patients = patientRepository.GetAll().ToList(); 
            foreach (Patient patient in patients)
            {
                if (patient.email.Equals(email) && patient.password.Equals(password))
                {
                    return patient;
                }
            }
            return null;
        }

        public Patient getByJMBG(String JMBG)
        {
            List<Patient> patients = patientRepository.GetAll().ToList();
            foreach (Patient patient in patients)
            {
                if (patient.jmbg != null)
                {
                    if (patient.jmbg.Equals(JMBG))
                    {
                        return patient;
                    }
                }
            }
            return null;
        }

        public List<Report> GetReports(long id)
        {
            Patient patient = patientRepository.Get(id);
            return patient.medicalRecord.reports;
        }

        public void CreateReport(long id, Report report) 
        {
            Patient patient = patientRepository.Get(id);
            patient.medicalRecord.reports.Add(report);
            patientRepository.Update(patient);
        }

        public List<SpecialistReferral> GetSpecialistReferrals(long id)
        {
            Patient patient = patientRepository.Get(id);
            return patient.medicalRecord.specialistReferrals;
        }

        public void CreateSpecialistReferral(long id, SpecialistReferral specialistReferral)
        {
            Patient patient = patientRepository.Get(id);
            patient.medicalRecord.specialistReferrals.Add(specialistReferral);
        }

        public List<LaboratoryReferral> GetLaboratoryReferrals (long id)
        {
            Patient patient = patientRepository.Get(id);
            return patient.medicalRecord.laboratoryReferrals;
        }

        public void CreateLaboratoryReferral(long id, LaboratoryReferral laboratoryReferral)
        {
            Patient patient = patientRepository.Get(id);
            patient.medicalRecord.laboratoryReferrals.Add(laboratoryReferral);
        }

        public List<HospitalizationReferral> GetHospitalizationReferrals(long id)
        {
            Patient patient = patientRepository.Get(id);
            return patient.medicalRecord.hospitalizationReferrals;
        }

        public void CreateHospitalizationReferral(long id, HospitalizationReferral hospitalizationReferral)
        {
            Patient patient = patientRepository.Get(id);
            patient.medicalRecord.hospitalizationReferrals.Add(hospitalizationReferral);
        }

        public List<DrugPrescription> GetDrugPrescriptions (long id)
        {
            Patient patient = patientRepository.Get(id);
            return patient.medicalRecord.drugPerscriptions;
        }

        public void CreateDrugPerscription (long id, DrugPrescription drugPrescription)
        {
            Patient patient = patientRepository.Get(id);
            patient.medicalRecord.drugPerscriptions.Add(drugPrescription);
        }

        public bool IsGuest(long id)
        {
            Patient patient = patientRepository.Get(id);
            return patient.isGuest;
        }
      
      
        public void CreateGuest(Patient patient)
        {
            patient.isGuest = true;
            patientRepository.Create(patient);
        }

        
   }
}