using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Controller
{
    public class SecretaryController : IController<Secretary, long>
    {
        private readonly SecretaryService service;
        public SecretaryController(SecretaryService service)
        {
            this.service = service;
        }

        public Secretary Create(Secretary entity) => service.Create(entity);

        public void Delete(Secretary entity) => service.Delete(entity);

        public Secretary Get(long id) => service.Get(id);

        public IEnumerable<Secretary> GetAll() => service.GetAll();

        public void Update(Secretary entity) => service.Update(entity);


    }
}


