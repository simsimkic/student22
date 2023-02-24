using Model.Doctor;
using ProjekatKlinika.Controller;
using ProjekatKlinika.Service;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class ArticleController : IController<Article, long>
   {
        private readonly ArticleService service;
        public ArticleController(ArticleService service)
        {
            this.service = service;
        }

        public IEnumerable<Article> GetByCategory(ArticleCategory articleCategory) => service.GetByCategory(articleCategory);

        public Article Create(Article entity) => service.Create(entity);

        public void Delete(Article entity) => service.Delete(entity);

        public Article Get(long id) => service.Get(id);

        public IEnumerable<Article> GetAll() => service.GetAll();

        public void Update(Article entity) => service.Update(entity);
    }
}