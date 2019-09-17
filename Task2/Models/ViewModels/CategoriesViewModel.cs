using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Task2.Models.ViewModels
{
    public class CategoriesViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentUserId { get; set; }
    }
}
