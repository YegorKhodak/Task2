using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public List<Order> Orders { get; set; }
        public int UserId { get; set; }
    }
}
