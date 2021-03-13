using MVCCRUDSHOP.Models;
using MVCCRUDSHOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCCRUDSHOP.Repository
{
    interface IProductRepository
    {
        List<ProductViewModel> Index();
        ProductViewModel Add();
        ProductViewModel Add(ProductViewModel productViewModel);
        ProductViewModel Edit(int id);
        ProductViewModel Edit(ProductViewModel productViewModel);
        Product Delete(int id);
    }
}
