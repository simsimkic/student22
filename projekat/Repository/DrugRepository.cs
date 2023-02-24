/***********************************************************************
 * Module:  DrugRepository.cs
 * Purpose: Definition of the Class Repository.DrugRepository
 ***********************************************************************/

using Model.Manager;
using ProjekatKlinika.Repository.Abstract.ManagerAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class DrugRepository : JsonRepository<Drug, long>, IDrugRepository
    {
        private const string ENTITY_NAME = "Drug";
        public DrugRepository(IJsonStream<Drug> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }
   }
}