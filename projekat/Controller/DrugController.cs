/***********************************************************************
 * Module:  DrugController.cs
 * Purpose: Definition of the Class Controller.DrugController
 ***********************************************************************/

using Model.Manager;
using Model.Users;
using ProjekatKlinika.Controller;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class DrugController : IController<Drug, long>
    {
        private readonly DrugService service;
        public DrugController(DrugService service)
        {
            this.service = service;
        }

        public Drug Create(Drug entity) => service.Create(entity);

        public void Delete(Drug entity) => service.Delete(entity);

        public Drug Get(long id) => service.Get(id);

        public IEnumerable<Drug> GetAll() => service.GetAll();

        public void Update(Drug entity) => service.Update(entity);
    }
}