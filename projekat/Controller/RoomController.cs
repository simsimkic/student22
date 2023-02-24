/***********************************************************************
 * Module:  RoomController.cs
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model.Manager;
using ProjekatKlinika.Controller;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController : IController<Room, long>
    {

        private readonly RoomService service;
        public RoomController(RoomService service)
        {
            this.service = service;
        }

        public Room Create(Room entity) => service.Create(entity);

        public void Delete(Room entity) => service.Delete(entity);

        public Room Get(long id) => service.Get(id);

        public IEnumerable<Room> GetAll() => service.GetAll();

        public void Update(Room entity) => service.Update(entity);

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

        public Service.RoomService roomService;

     */
    }
}