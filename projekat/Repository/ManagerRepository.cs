/***********************************************************************
 * Module:  ManagerRepository.cs
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using Model.Users;
using ProjekatKlinika.Repository.Abstract.ManagerAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class ManagerRepository : JsonRepository<Manager, long>, IManagerRepository
    {
        private const string ENTITY_NAME = "Manager";
        public ManagerRepository(IJsonStream<Manager> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }
        /*
        private static List<Manager> managers;
      public Manager GetManager(String username)
      {
         // TODO: implement
         return null;
      }
   */
   }
}