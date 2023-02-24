using Model.Doctor;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Service
{
    public class ArticleCategoryService : IService<ArticleCategory, long>
    {
        IArticleCategoryRepository articleCategoryRepository;
        public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
        }

        public ArticleCategory Create(ArticleCategory entity) => articleCategoryRepository.Create(entity);

        public void Delete(ArticleCategory entity) => articleCategoryRepository.Delete(entity);

        public ArticleCategory Get(long id) => articleCategoryRepository.Get(id);

        public IEnumerable<ArticleCategory> GetAll() => articleCategoryRepository.GetAll();

        public void Update(ArticleCategory entity) => articleCategoryRepository.Update(entity);
    }
}
