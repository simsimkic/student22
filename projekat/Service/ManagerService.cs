/***********************************************************************
 * Module:  ManagerService.cs
 * Purpose: Definition of the Class Service.ManagerService
 ***********************************************************************/

using Model.Users;
using ProjekatKlinika.Repository.Abstract.ManagerAbstract;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class ManagerService : IService<Manager, long>
    {
        private readonly IManagerRepository managerRepository;

    public ManagerService(IManagerRepository managerRepository)
    {
        this.managerRepository = managerRepository;
    }

   public Manager LogIn(String email, String password)
    {
        List<Manager> managers = managerRepository.GetAll().ToList();
        foreach (Manager manager in managers)
        {
            if (manager.email.Equals(email) && manager.password.Equals(password))
            {
                return manager;
            }
        }
        return null;
   }
        public Manager Create(Manager entity) => managerRepository.Create(entity);

    public void Delete(Manager entity) => managerRepository.Delete(entity);

    public Manager Get(long id) => managerRepository.Get(id);

    public System.Collections.Generic.IEnumerable<Manager> GetAll() => managerRepository.GetAll();

    public void Update(Manager entity) => managerRepository.Update(entity);
}
}