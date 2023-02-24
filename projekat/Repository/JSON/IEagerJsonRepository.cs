using ProjekatKlinika.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.JSON
{
    public interface IEagerJsonRepository<C, ID>
        where C : IIdentifiable<ID>
        where ID : IComparable
    {
        C GetEager(ID id);
        IEnumerable<C> GetAllEager();
    }
}
