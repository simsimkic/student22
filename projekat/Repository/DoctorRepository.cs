/***********************************************************************
 * Module:  DoctorRepository.cs
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using Model.Users;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class DoctorRepository : JsonRepository<Doctor, long>, IDoctorRepository
    {
        private const string ENTITY_NAME = "Doctor";

        public DoctorRepository(IJsonStream<Doctor> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }
    }
}