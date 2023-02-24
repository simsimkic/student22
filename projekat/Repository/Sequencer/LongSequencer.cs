using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.Sequencer
{
    public class LongSequencer : ISequencer<long>
    {
        private long _nextId;

        public long GenerateId() => _nextId++;

        public void Initialize(long initId) => _nextId = initId;
    }
}
