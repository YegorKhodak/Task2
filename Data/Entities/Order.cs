using System;
using Newtonsoft.Json;

//using Newtonsoft.Json;

namespace Data.Entities
{
    public class Order
    {
        public Order()
        {
            OrderStatus = OrderStatus.Created;
        }
        public Order(int userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
            OrderStatus = OrderStatus.Created;
            DateCreated = DateTime.Now;
        }
        public int Id { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public enum OrderStatus
    {
        Created = 0,
        ConfirmedByUser = 1,
        ConfirmedByAdmin = 2
    }
}
