using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.Abstract
{
    public interface IRepository<C, ID>
        where C : IIdentifiable<ID>
        where ID : IComparable
    {
        C Get(ID id);
        IEnumerable<C> GetAll();
        C Create(C entity);
        void Update(C entity);
        void Delete(C entity);
        IEnumerable<C> Find(Func<C, bool> predicate);
    }
}
