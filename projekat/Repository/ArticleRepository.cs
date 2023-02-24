using Model.Doctor;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository
{
    public class ArticleRepository : JsonRepository<Article, long>, IArticleRepository
    {
        private const string ENTITY_NAME = "Article";
        public ArticleRepository(IJsonStream<Article> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public IEnumerable<Article> GetByCategory(ArticleCategory category)
            => Find(article => article.Category.Id == category.Id);
    }
}
