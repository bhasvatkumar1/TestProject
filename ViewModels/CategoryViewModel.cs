using MVCCRUDSHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUDSHOP.ViewModels
{
    public class CategoryViewModel
    {
        

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List <Category> Categorylist { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}