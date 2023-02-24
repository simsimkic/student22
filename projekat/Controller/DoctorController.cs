/***********************************************************************
 * Module:  DoctorController.cs
 * Purpose: Definition of the Class Controller.DoctorController
 ***********************************************************************/

using Model.Doctor;
using Model.Users;
using ProjekatKlinika.Controller;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class DoctorController : IController<Doctor, long>
    {
        private readonly DoctorService service;
        public DoctorController(DoctorService service)
        {
            this.service = service;
        }

        public Doctor Create(Doctor entity) => service.Create(entity);

        public void Delete(Doctor entity) => service.Delete(entity);

        public Doctor Get(long id) => service.Get(id);

        public IEnumerable<Doctor> GetAll() => service.GetAll();

        public void Update(Doctor entity) => service.Update(entity);

        public Doctor LogIn(String email, String password) => service.LogIn(email, password);
    }
}
