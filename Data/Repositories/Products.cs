using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;

namespace Data.Repositories
{
    public class Products
    {
        private readonly ApplicationContext _db;

        public Products(ApplicationContext db)
        {
            _db = db;
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _db.Products.Where(_ => _.CategoryId == categoryId).ToList();
        }
    }
}
