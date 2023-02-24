using ProjekatKlinika.Model.Doctor.Util;
using ProjekatKlinika.Repository.Abstract;
using System;

namespace Model.Doctor
{
    public class Article : IIdentifiable<long>
   {
        public long Id { get; set; }
        public ArticleCategory Category { get; set; }
        public ArticleHeadline Headline { get; set; }
        public ArticleText Text { get; set; }
        public Users.Doctor Author { get; set; }
        public DateTime Published { get; set; }

        public Article(long id)
        {
            Id = id;
        }

        public Article(long id, ArticleCategory category, ArticleHeadline headline, ArticleText text, Users.Doctor author, DateTime published)
        {
            Id = id;
            Category = category;
            Headline = headline;
            Text = text;
            Author = author;
            Published = published;
        }

        public Article()
        {
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}