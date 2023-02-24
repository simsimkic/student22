using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.JSON.Stream
{
    public class JsonStream<C> : IJsonStream<C> where C : class
    {
        private readonly string path;

        public JsonStream(string path)
        {
            this.path = path;
        }
        public void AppendToFile(C entity)
            => File.AppendAllText(path,
               JsonConvert.SerializeObject(entity) + Environment.NewLine);

        public IEnumerable<C> ReadAll()
            => File.ReadAllLines(path)
                .Select(JsonConvert.DeserializeObject<C>)
                .ToList();

        public void SaveAll(IEnumerable<C> entities)
            => WriteAllLinesToFile(
                 entities
                 .Select(JsonConvert.SerializeObject)
                 .ToList());
        public void WriteAllLinesToFile(IEnumerable<string> content)
            => File.WriteAllLines(path, content.ToArray());
    }
}
