/***********************************************************************
 * Module:  SecretaryService.cs
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using Model.Users;
using ProjekatKlinika.Repository.Abstract.PatientAbstract;
using ProjekatKlinika.Repository.Abstract.SecretaryAbstract;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class SecretaryService : IService<Secretary, long>
    {
        private readonly ISecretaryRepository secretaryRepository;
        private readonly IPatientRepository patientRepository;

        public SecretaryService(ISecretaryRepository secretaryRepository)
        {
            this.secretaryRepository = secretaryRepository;
        }

        public Secretary Create(Secretary entity) => secretaryRepository.Create(entity);

        public void SavePatientFromGuest(Patient patient) 
        {
            patient.isGuest = false;
            patientRepository.Update(patient);
        }

        public Secretary LogIn(String email, String password)
        {
            List<Secretary> secretaries = secretaryRepository.GetAll().ToList();
            foreach (Secretary secretary in secretaries)
            {
                if (secretary.email.Equals(email) && secretary.password.Equals(password))
                {
                    return secretary;
                }
            }
            return null;
        }

        public void Delete(Secretary entity) => secretaryRepository.Delete(entity);

        public Secretary Get(long id) => secretaryRepository.Get(id);

        public System.Collections.Generic.IEnumerable<Secretary> GetAll() => secretaryRepository.GetAll();

        public void Update(Secretary entity) => secretaryRepository.Update(entity);
    }
}