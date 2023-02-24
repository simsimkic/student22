using Model.Doctor;
using ProjekatKlinika.Exception;
using ProjekatKlinika.Model.Doctor.Util;
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
    public class ArticleCategoryRepository : JsonRepository<ArticleCategory, long>, IArticleCategoryRepository
    {
        private const string ENTITY_NAME = "Article category";
        private const string NOT_UNIQUE_ERROR = "{0} with {1} = {2} is not unique.";
        public ArticleCategoryRepository(IJsonStream<ArticleCategory> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public bool IsCategoryUnique(ArticleCategory category)
            => Find(c => c.Name.Value.Equals(category.Name.Value)) == null;

        public new ArticleCategory Create(ArticleCategory category)
        {
                return base.Create(category);
            //else
                //throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, entityName, "name", category.Name));
        }

    }
}
