using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;

namespace Data.Repositories
{
    public class Categories
    {
        private readonly ApplicationContext _db;

        public Categories(ApplicationContext db)
        {
            _db = db;
        }

        public List<Category> All()
        {
            return _db.Categories.ToList();
        }
    }
}
