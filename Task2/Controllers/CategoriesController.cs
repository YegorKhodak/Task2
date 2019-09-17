using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Categories _categories;

        public CategoriesController(Categories categories)
        {
            _categories = categories;
        }
        public IActionResult Index(int userId)
        {
            var categories = _categories.All();

            var vm = new CategoriesViewModel()
            {
                Categories = categories,
                CurrentUserId = userId
            };

            return View(vm);
        }
    }
}