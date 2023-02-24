/***********************************************************************
 * Module:  RoomService.cs
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using Model.Manager;
using ProjekatKlinika.Repository.Abstract.ManagerAbstract;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RoomService : IService<Room, long>
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public Room Create(Room entity) => roomRepository.Create(entity);

        public void Delete(Room entity) => roomRepository.Delete(entity);

        public Room Get(long id) => roomRepository.Get(id);

        public System.Collections.Generic.IEnumerable<Room> GetAll() => roomRepository.GetAll();

        public void Update(Room entity) => roomRepository.Update(entity);
    }










      /*public int CreateRoom()
      {
         // TODO: implement
         return 0;
      }
      
      public int DeleteRoom()
      {
         // TODO: implement
         return 0;
      }
      
      public int UpdateRoomPurpose()
      {
         // TODO: implement
         return 0;
      }
      
      public int ScheduleRenovation()
      {
         // TODO: implement
         return 0;
      }
      
      public int GenerateStatisticsReport()
      {
         // TODO: implement
         return 0;
      }
      
      public int HospitalizePatient()
      {
         // TODO: implement
         return 0;
      }
      
      public List<OperatingRoom> GetOperatingRooms()
      {
         // TODO: implement
         return null;
      }
   
      public System.Collections.ArrayList roomRepository;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRoomRepository()
      {
         if (roomRepository == null)
            roomRepository = new System.Collections.ArrayList();
         return roomRepository;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRoomRepository(System.Collections.ArrayList newRoomRepository)
      {
         RemoveAllRoomRepository();
         foreach (Repository.RoomRepository oRoomRepository in newRoomRepository)
            AddRoomRepository(oRoomRepository);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRoomRepository(Repository.RoomRepository newRoomRepository)
      {
         if (newRoomRepository == null)
            return;
         if (this.roomRepository == null)
            this.roomRepository = new System.Collections.ArrayList();
         if (!this.roomRepository.Contains(newRoomRepository))
            this.roomRepository.Add(newRoomRepository);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRoomRepository(Repository.RoomRepository oldRoomRepository)
      {
         if (oldRoomRepository == null)
            return;
         if (this.roomRepository != null)
            if (this.roomRepository.Contains(oldRoomRepository))
               this.roomRepository.Remove(oldRoomRepository);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRoomRepository()
      {
         if (roomRepository != null)
            roomRepository.Clear();
      }
   */
}
