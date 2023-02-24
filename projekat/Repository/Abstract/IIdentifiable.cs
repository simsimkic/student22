using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.Abstract
{
    public interface IIdentifiable<ID>
    {
        ID GetId();
        void SetId(ID id);
    }
}
