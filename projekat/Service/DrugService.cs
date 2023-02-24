/***********************************************************************
 * Module:  DrugService.cs
 * Purpose: Definition of the Class Service.DrugService
 ***********************************************************************/

using Model.Manager;
using Model.Users;
using ProjekatKlinika.Repository.Abstract.ManagerAbstract;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DrugService : IService<Drug, long>
    {
        IDrugRepository drugRepository;
        public DrugService(IDrugRepository drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        public Drug Create(Drug entity) => drugRepository.Create(entity);

        public void Delete(Drug entity) => drugRepository.Delete(entity);

        public Drug Get(long id) => drugRepository.Get(id);

        public IEnumerable<Drug> GetAll() => drugRepository.GetAll();

        public void Update(Drug entity) => drugRepository.Update(entity);
    }
}
