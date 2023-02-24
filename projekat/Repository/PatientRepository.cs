/***********************************************************************
 * Module:  RoomRepository.cs
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using Model.Patient;
using Model.Users;
using ProjekatKlinika.Repository.Abstract.PatientAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Repository
{
   public class PatientRepository : JsonRepository<Patient, long>, IPatientRepository
   {

        private const string ENTITY_NAME = "Patient";
        public PatientRepository(IJsonStream<Patient> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }

    }
}