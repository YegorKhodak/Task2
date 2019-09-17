using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Products _products;

        public ProductsController(Products products)
        {
            _products = products;
        }
        public IActionResult Index(int userId, int categoryId)
        {
            var products = _products.GetAllByCategoryId(categoryId);

            var vm = new ProductsViewModel()
            {
                Products = products,
                CurrentUserId = userId
            };

            return View(vm);
        }
    }
}