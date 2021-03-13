using MVCCRUDSHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUDSHOP.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Productlist { get; set; }
        public List<Category> Categorylist { get; set; }

        public virtual Category Category { get; set; }
    }
}