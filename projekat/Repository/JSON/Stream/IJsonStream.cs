using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.JSON.Stream
{
    public interface IJsonStream<C>
    {
        void SaveAll(IEnumerable<C> entities);
        IEnumerable<C> ReadAll();
        void AppendToFile(C entity);
    }
}
