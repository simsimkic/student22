using ProjekatKlinika.Exception;
using ProjekatKlinika.Repository.Abstract;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.JSON
{
    public class JsonRepository<C, ID> : IRepository<C, ID>
        where C : IIdentifiable<ID>
        where ID : IComparable
    {
        protected string NOT_FOUND_ERROR = "{0} with {1} = {2} not found.";
        private ID id;
        
        protected string entityName;
        protected IJsonStream<C> stream;
        protected ISequencer<ID> sequencer;

        public JsonRepository(string entityName, IJsonStream<C> stream, ISequencer<ID> sequencer)
        {
            this.entityName = entityName;
            this.stream = stream;
            this.sequencer = sequencer;
            InitializeId();
        }

        public C Create(C entity)
        {
            entity.SetId(sequencer.GenerateId());
            stream.AppendToFile(entity);
            return entity;
        }

        public void Delete(C entity)
        {
            var entities = stream.ReadAll().ToList();
            var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                stream.SaveAll(entities);
            }
            else
                ThrowEntityNotFoundException("id", entity.GetId());
        }

        public IEnumerable<C> Find(Func<C, bool> predicate)
            => stream
            .ReadAll()
            .Where(predicate);

        public C Get(ID id)
        {
            try
            {
                return stream
                    .ReadAll()
                    .SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
            } catch
            {
                ThrowEntityNotFoundException("id", id);
                return default(C);
            }
        }

        public IEnumerable<C> GetAll() => stream.ReadAll();

        public void Update(C entity)
        {
            try
            {
                var entities = stream.ReadAll().ToList();
                entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
                stream.SaveAll(entities);
            } catch
            {
                ThrowEntityNotFoundException("id", entity.GetId());
            }
        }
        protected void InitializeId() => sequencer.Initialize(GetMaxId(stream.ReadAll()));

        private ID GetMaxId(IEnumerable<C> entities)
           => entities.Count() == 0 ? id : entities.Max(entity => entity.GetId());

        private void ThrowEntityNotFoundException(string key, object value)
          => throw new EntityNotFoundException(string.Format(NOT_FOUND_ERROR, entityName, key, value));
    }
}
