﻿using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.Abstract.DoctorAbstract
{
    public interface IArticleRepository : IRepository<Article, long>
    {
        IEnumerable<Article> GetByCategory(ArticleCategory category);
    }
}
