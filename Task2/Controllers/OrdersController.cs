using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Orders _orders;

        public OrdersController(Orders orders)
        {
            _orders = orders;
        }
        public IActionResult CreateOrder(int userId, int productId)
        {
            var newOrder = _orders.CreateNewOrder(userId, productId);

            var orderWithInclude = _orders.GetOrderWithProductById(newOrder.Id);

            return View(orderWithInclude);
        }
        public IActionResult ConfirmOrderByAdmin(int orderId)
        {
            var order = _orders.GetOrderWithProductById(orderId);

            return View(order);
        }

        [HttpPost]
        public JsonResult ConfirmOrderByUser([FromBody] ConfirmOrderByUserDto dto)
        {
            var order = _orders.GetById(dto.OrderId);
            var result = new JsonAnswer();
            if (order == null)
            {
                return Json(result);
            }

            order.OrderStatus = OrderStatus.ConfirmedByUser;
            _orders.UpdateOrder(order);

            result.Ok = true;
            result.UserId = order.UserId;

            return Json(result);
        }

        [HttpPost]
        public JsonResult ConfirmOrderByAdmin([FromBody] ConfirmOrderByUserDto dto)
        {
            var order = _orders.GetById(dto.OrderId);
            var result = new JsonAnswer();
            if (order == null)
            {
                return Json(result);
            }

            order.OrderStatus = OrderStatus.ConfirmedByAdmin;
            _orders.UpdateOrder(order);

            result.Ok = true;

            return Json(result);
        }

        public IActionResult ForUser(int userId)
        {
            var orders = _orders.GetOrdersWithProductWithUserId(userId);

            var vm = new ListOfOrderForUserViewModel();
            vm.Orders = orders;
            vm.CurrentUserId = userId;

            return View(vm);
        }
        public IActionResult ForAdmin()
        {
            var orders = _orders.GetAllWithProduct();

            var vm = new ListOfOrderForUserViewModel();
            vm.Orders = orders;

            return View(vm);
        }
    }

    public class ConfirmOrderByUserDto
    {
        public int OrderId { get; set; }
    }
}