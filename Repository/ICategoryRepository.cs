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
    interface ICategoryRepository
    {
        List<CategoryViewModel> Index();
        CategoryViewModel Add();
        CategoryViewModel Add(CategoryViewModel categoryViewModel);
        CategoryViewModel Edit(int id);
        CategoryViewModel Edit(CategoryViewModel categoryViewModel);
        Category Delete(int id);
    }
}
 