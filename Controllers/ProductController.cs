using MVCCRUDSHOP.Models;
using MVCCRUDSHOP.Repository;
using MVCCRUDSHOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDSHOP.Controllers
{
    public class ProductController : Controller
    {
        private MVCCRUDSHOPEntities db = new MVCCRUDSHOPEntities();

        private IProductRepository _productRepository;
        
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
           var product= _productRepository.Index();
            return View(product);
        }
       
        //GET
        public ActionResult Add()
        {
            var product = _productRepository.Add();

            return View(product);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            var product = _productRepository.Add(productViewModel);

            return View(product);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = _productRepository.Edit(id);
            return View(cat);
        }

        [HttpPost]
        public JsonResult Edit(ProductViewModel productViewModel)
        {
            var product = _productRepository.Edit(productViewModel);

            return Json(product);
        }

        public ActionResult Delete(int id)
        {
            var cat = _productRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}