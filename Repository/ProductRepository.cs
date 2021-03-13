using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCCRUDSHOP.Models;
using MVCCRUDSHOP.ViewModels;

namespace MVCCRUDSHOP.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MVCCRUDSHOPEntities db = new MVCCRUDSHOPEntities();

        public ProductViewModel Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Categorylist = categoryList();

            return productViewModel;
        }

        public ProductViewModel Add(ProductViewModel productViewModel)
        {
            Product product = new Product();
            product.CategoryId = productViewModel.CategoryId;
            product.ProductName = productViewModel.ProductName;
            product.ProductPrice = productViewModel.ProductPrice;

            db.Products.Add(product);
            db.SaveChanges();


            productViewModel.Categorylist = categoryList();

            return productViewModel;
        }

        public Product Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            return product;
        }

        public ProductViewModel Edit(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            Product product = db.Products.Find(id);
            productViewModel = BindData(product);

            return productViewModel;
        }

        public ProductViewModel Edit(ProductViewModel productViewModel)
        {
            Product product = db.Products.Find(productViewModel.ProductId);
            product.ProductName = productViewModel.ProductName;
            product.ProductPrice = productViewModel.ProductPrice;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return productViewModel;
        }

        public List<ProductViewModel> Index()
        {
            List<ProductViewModel> productviewmodel = new List<ProductViewModel>();
            List<Product> product = db.Products.ToList();

            foreach (Product item in product)
            {
                ProductViewModel pt = BindData(item);
                productviewmodel.Add(pt);
            }
            return productviewmodel;
        }


        private ProductViewModel BindData(Product item)
        {
            return new ProductViewModel()
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                ProductPrice = item.ProductPrice,
                CategoryId = item.CategoryId,
                CategoryName=item.Category.CategoryName
            };
        }

        private List<Category> categoryList()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = db.Categories.ToList();
            return categoryList;
        }
    }
}
