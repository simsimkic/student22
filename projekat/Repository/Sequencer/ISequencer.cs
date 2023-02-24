using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.Sequencer
{
    public interface ISequencer<T>
    {
        void Initialize(T initId);

        T GenerateId();
    }
}
