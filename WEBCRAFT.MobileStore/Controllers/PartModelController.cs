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
    public class PartModelController : Controller
    {
        public PartModelController()
        : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }
        public PartModelController(UnitOfWork u)
        {
            Uow = u;
        }
        public UnitOfWork Uow { get; set; }
        // GET: Subcategory
        public ActionResult Index()
        {
            var partModels = Uow.Subcategory.GetAll();
            var brands = Uow.Category.GetAll();
            SubcategoryHomeViewModel vm = new SubcategoryHomeViewModel { Subcategory = partModels.ToList() , Category= brands.ToList()};
            return View(vm);
        }

        public ActionResult Manage(int? id)
        {
            ViewBag.Mode = "Create";
            Subcategory p = null;
            if (id != null)
            {
                ViewBag.Mode = "Edit";
                p = Uow.Subcategory.Get((int)id);
            }
            var brands = Uow.Category.GetAll();
            SubcategoryViewModel vm = new SubcategoryViewModel { Subcategory = p , Categories = brands.ToList()};
            Uow.Dispose();
            return View("Manage", vm);
        }

        [HttpPost]
        public ActionResult Manage(Subcategory Subcategory)
        {
            if (Subcategory.Id != 0)
            {
                var pToUpdate = Uow.Subcategory.Get(Subcategory.Id);
                pToUpdate.Name = Subcategory.Name;
                pToUpdate.Fk_CategoryId = Subcategory.Fk_CategoryId;
            }
            else
            {
                Uow.Subcategory.Add(Subcategory);
            }
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("index", "Category");
        }
        public ActionResult Delete(int id)
        {
            Subcategory Subcategory = Uow.Subcategory.Get(id);
            Uow.Subcategory.Remove(Subcategory);
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }

    }
}