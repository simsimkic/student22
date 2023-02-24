using Model.Doctor;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Controller
{
    public class ArticleCategoryController : IController<ArticleCategory, long>
    {
        private readonly IService<ArticleCategory, long> service;
        public ArticleCategoryController(IService<ArticleCategory, long> service)
        {
            this.service = service;
        }

        public ArticleCategory Create(ArticleCategory entity) => service.Create(entity);

        public void Delete(ArticleCategory entity) => service.Delete(entity);

        public ArticleCategory Get(long id) => service.Get(id);

        public IEnumerable<ArticleCategory> GetAll() => service.GetAll();

        public void Update(ArticleCategory entity) => service.Update(entity);
    }
}