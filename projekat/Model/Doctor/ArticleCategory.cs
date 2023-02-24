using ProjekatKlinika.Model.Doctor.Util;
using ProjekatKlinika.Repository.Abstract;
using System;

namespace Model.Doctor
{
   public class ArticleCategory : IIdentifiable<long>
   {
        public long Id { get; set; }
        public ArticleCategoryName Name { get; set; }
        public ArticleCategory(long id)
        {
            Id = id;
        }
        public ArticleCategory(long id, ArticleCategoryName name)
        {
            Id = id;
            Name = name;
        }

        public ArticleCategory()
        {
        }

        public override string ToString()
        {
            return Name.ToString();
        }
        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}