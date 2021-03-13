using MVCCRUDSHOP.Models;
using MVCCRUDSHOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDSHOP.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private MVCCRUDSHOPEntities db = new MVCCRUDSHOPEntities();

        public CategoryViewModel Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();

            return categoryViewModel;
        }

        public CategoryViewModel Add(CategoryViewModel categoryViewModel)
        {
                Category category = new Category();
                category.CategoryName = categoryViewModel.CategoryName;
                db.Categories.Add(category);
                db.SaveChanges();

            return categoryViewModel;
        }

        public Category Delete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();

            return category;
        }

        public CategoryViewModel Edit(int id)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            Category category = db.Categories.Find(id);
            categoryViewModel = BindData(category);

            return categoryViewModel;
        }

        public CategoryViewModel Edit(CategoryViewModel categoryViewModel)
        {
            Category ct = db.Categories.Find(categoryViewModel.CategoryId);
            ct.CategoryName = categoryViewModel.CategoryName;
            db.Entry(ct).State = EntityState.Modified;
            db.SaveChanges();

            return categoryViewModel;
        }

        public List<CategoryViewModel> Index()
        {
            List<CategoryViewModel> categoryviewmodel = new List<CategoryViewModel>();
            List<Category> category = db.Categories.ToList();

            foreach (Category item in category)
            {
                CategoryViewModel ct = BindData(item);
                categoryviewmodel.Add(ct);
            }

            return categoryviewmodel;
        }

        private CategoryViewModel BindData(Category item)
        {
            return new CategoryViewModel()
            {
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName
            };

        }
    }
}