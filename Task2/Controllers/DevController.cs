using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class DevController : Controller
    {
        private readonly ApplicationContext _db;

        public DevController(ApplicationContext db)
        {
            _db = db;
        }

        public string CreateUsers()
        {
            var newUsers = new List<User>
            {
                new User()
                {
                    Name = "Yegor",
                    Password = "password"
                },
                new User()
                {
                    Name = "Ivan",
                    Password = "password"
                },
                new User()
                {
                    Name = "Peter",
                    Password = "password"
                },
            };

            _db.Users.AddRange(newUsers);
            _db.SaveChanges();

            return "ok";
        }

        public string CreateCategories()
        {
            var newCategories = new List<Category>();

            newCategories.Add(new Category()
            {
                Name = "Cars"
            });

            newCategories.Add(new Category()
            {
                Name = "Tracks"
            });

            newCategories.Add(new Category()
            {
                Name = "Bikes"
            });


            _db.Categories.AddRange(newCategories);
            _db.SaveChanges();

            return "ok";
        }
        public string CreateProducts()
        {
            var newProducts = new List<Product>();

            newProducts.Add(new Product()
            {
                CategoryId = 1,
                Price = 20,
                Name = "Ferrari"
            });
            newProducts.Add(new Product()
            {
                CategoryId = 1,
                Price = 20,
                Name = "Ford"
            });
            newProducts.Add(new Product()
            {
                CategoryId = 1,
                Price = 20,
                Name = "Audi"
            });

            newProducts.Add(new Product()
            {
                CategoryId = 2,
                Price = 20,
                Name = "MAN"
            });
            newProducts.Add(new Product()
            {
                CategoryId = 2,
                Price = 20,
                Name = "Track2"
            });
            newProducts.Add(new Product()
            {
                CategoryId = 2,
                Price = 20,
                Name = "Track3"
            });

            newProducts.Add(new Product()
            {
                CategoryId = 3,
                Price = 0,
                Name = "Bike from my grandpa"
            });
            newProducts.Add(new Product()
            {
                CategoryId = 3,
                Price = 10,
                Name = "New bike"
            });

            _db.Products.AddRange(newProducts);
            _db.SaveChanges();

            return "ok";
        }
    }
}
