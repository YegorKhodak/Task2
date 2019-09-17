using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class CartController : Controller
    {
        private readonly Orders _orders;

        public CartController(Orders orders)
        {
            _orders = orders;
        }
        public IActionResult Index(int userId)
        {
            var allOrdersForCart = _orders.GetOrdersWithProductWithUserIdAndNotConfirmed(userId);

            var vm = new CartIndexViewModel();

            vm.Orders = allOrdersForCart;
            vm.UserId = userId;

            return View(vm);
        }

        public IActionResult CreateOrder(int productId, int userId)
        {
            var newOrder = _orders.CreateNewOrder(userId, productId);

            var allOrdersForCart = _orders.GetOrdersWithProductWithUserIdAndNotConfirmed(userId);

            var vm = new CartIndexViewModel();

            vm.Orders = allOrdersForCart;
            vm.UserId = userId;

            return View("Index", vm);
        }

        public IActionResult ConfirmOrder(int userId, int orderId)
        {
            var orderWithInclude = _orders.GetOrderWithProductById(orderId);

            return View(orderWithInclude);
        }
    }
}