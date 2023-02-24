using Model.Doctor;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using ProjekatKlinika.Service;
using System;

namespace Service
{
    public class ArticleService : IService<Article, long>
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public Article Create(Article entity) => articleRepository.Create(entity);

        public void Delete(Article entity) => articleRepository.Delete(entity);

        public Article Get(long id) => articleRepository.Get(id);

        public System.Collections.Generic.IEnumerable<Article> GetAll() => articleRepository.GetAll();

        public void Update(Article entity) => articleRepository.Update(entity);
        
        public System.Collections.Generic.IEnumerable<Article> GetByCategory(ArticleCategory articleCategory) => articleRepository.GetByCategory(articleCategory);
    }
}