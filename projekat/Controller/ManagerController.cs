using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Controller
{
    public class ManagerController : IController<Manager, long>
    {
        private readonly ManagerService service;
        public ManagerController(ManagerService service)
        {
            this.service = service;
        }

        public Manager Create(Manager entity) => service.Create(entity);

        public void Delete(Manager entity) => service.Delete(entity);

        public Manager Get(long id) => service.Get(id);

        public IEnumerable<Manager> GetAll() => service.GetAll();

        public void Update(Manager entity) => service.Update(entity);

        public Manager LogIn(String email, String password)
        {
            return service.LogIn(email, password);
        }

    }
}

