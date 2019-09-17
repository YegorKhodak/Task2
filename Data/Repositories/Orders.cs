using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Orders
    {
        private readonly ApplicationContext _db;

        public Orders(ApplicationContext db)
        {
            _db = db;
        }

        public Order CreateNewOrder(int userId, int productId)
        {
            var newOrder = new Order(userId, productId);

            _db.Orders.Add(newOrder);
            _db.SaveChanges();

            return newOrder;
        }

        public Order GetOrderWithProductById(int id)
        {
            return _db.Orders.Include(_ => _.Product).FirstOrDefault(_ => _.Id == id);
        }

        public Order GetById(int id)
        {
            return _db.Orders.FirstOrDefault(_ => _.Id == id);
        }

        public void UpdateOrder(Order order)
        {
            _db.Update(order);
            _db.SaveChanges();
        }

        public List<Order> GetOrdersWithProductWithUserId(int userId)
        {
            return _db.Orders.Include(_ => _.Product).Where(_ => _.UserId == userId).ToList();
        }

        public List<Order> GetOrdersWithProductWithUserIdAndNotConfirmed(int userId)
        {
            return _db.Orders.Include(_ => _.Product).Where(_ => _.UserId == userId && _.OrderStatus == OrderStatus.Created).ToList();
        }

        public List<Order> GetAllWithProduct()
        {
            return _db.Orders.Include(_ => _.Product).ToList();
        }
    }
}
