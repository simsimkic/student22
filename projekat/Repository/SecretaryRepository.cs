using Model.Users;
using ProjekatKlinika.Repository.Abstract.SecretaryAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository
{
    public class SecretaryRepository : JsonRepository<Secretary, long>, ISecretaryRepository
    {
        private const string ENTITY_NAME = "Secretary";
        public SecretaryRepository(IJsonStream<Secretary> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }
    }
}
