using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    public class BrandController : Controller
    {
        public BrandController()
        : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }
        public BrandController(UnitOfWork u)
        {
            Uow = u;
        }
        public UnitOfWork Uow { get; set; }

        // GET: Category
        public ActionResult Index()
        {
            var brands = Uow.Category.GetAll();
            var viewModel = new CategoriesHomeViewModel { Categories = brands.ToList() };
            return View(viewModel);
        }

        public ActionResult Manage(int? id)
        {
            Category b = null;
            ViewBag.Mode = "Create";
            if (id != null)
            {
                ViewBag.Mode = "Edit";
                b = Uow.Category.Get((int)id);
            }
                CategoryVeiwModels bVM = new CategoryVeiwModels { Category = b};
                Uow.Dispose();
            return View("Create", bVM );
        }
        [HttpPost]
        public ActionResult Manage(Category category)
        {
            if (category.Id == 0)
            {
                Uow.Category.Add(category);
            }
            else
            {      
                Category BrandToUpdate = Uow.Category.Get(category.Id);
                BrandToUpdate.Name = category.Name;
            }

            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Category Category = Uow.Category.Get(id);
            Uow.Category.Remove(Category);
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }
    }
}