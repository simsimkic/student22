/***********************************************************************
 * Module:  RoomRepository.cs
 * Purpose: Definition of the Class Repository.RoomRepository
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
   public class RoomRepository : JsonRepository<Room, long>, IRoomRepository
    {
        private const string ENTITY_NAME = "Appointment";
        public RoomRepository(IJsonStream<Room> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }



        /* private static List<Room> rooms;

         public List<Room> GetRooms()
         {
             return rooms;
         }

         public List<OperatingRoom> GetOperatingRooms()
         {
            // TODO: implement
            return null;
         }*/

    }
}