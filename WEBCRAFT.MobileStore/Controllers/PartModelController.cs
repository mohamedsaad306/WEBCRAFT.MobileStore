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
        // GET: PartModel
        public ActionResult Index()
        {
            var partModels = Uow.PartModel.GetAll();
            var brands = Uow.Brand.GetAll();
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
                p = Uow.PartModel.Get((int)id);
            }
            var brands = Uow.Brand.GetAll();
            SubcategoryViewModel vm = new SubcategoryViewModel { PartModel = p , Categories = brands.ToList()};
            Uow.Dispose();
            return View("Manage", vm);
        }

        [HttpPost]
        public ActionResult Manage(Subcategory partModel)
        {
            if (partModel.Id != 0)
            {
                var pToUpdate = Uow.PartModel.Get(partModel.Id);
                pToUpdate.Name = partModel.Name;
                pToUpdate.Fk_CategoryId = partModel.Fk_CategoryId;
            }
            else
            {
                Uow.PartModel.Add(partModel);
            }
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("index", "Brand");
        }
        public ActionResult Delete(int id)
        {
            Subcategory partModel = Uow.PartModel.Get(id);
            Uow.PartModel.Remove(partModel);
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }

    }
}