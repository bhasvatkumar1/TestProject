using MVCCRUDSHOP.Models;
using MVCCRUDSHOP.Repository;
using MVCCRUDSHOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDSHOP.Controllers
{
    public class CategoryController : Controller
    {
        private MVCCRUDSHOPEntities db = new MVCCRUDSHOPEntities();

        private ICategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       
        // GET: Category
        public ActionResult Index()
        {
            var cat = _categoryRepository.Index();

            return View(cat);
        }

        private List<Category> categoryList()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = db.Categories.ToList();
            return categoryList;
        }

        //GET
        public ActionResult Add()
        {
            var cat = _categoryRepository.Add();

            return View(cat);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            var cat = _categoryRepository.Add(categoryViewModel);

            return View(cat);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = _categoryRepository.Edit(id);

            return View(cat);
        }

        [HttpPost]
        public JsonResult Edit(CategoryViewModel categoryViewModel)
        {
            var cat = _categoryRepository.Edit(categoryViewModel);

            return Json(cat);
        }
     
        public ActionResult Delete(int id)
        {
            var cat = _categoryRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}