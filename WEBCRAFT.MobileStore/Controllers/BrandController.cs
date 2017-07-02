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

        // GET: Brand
        public ActionResult Index()
        {
            var brands = Uow.Brand.GetAll();
            var viewModel = new BrandsHomeViewModel { Brands = brands.ToList() };
            return View(viewModel);
        }

        public ActionResult Create(int? id)
        {
            if (id == 0)
            {
                ViewBag.Mode = "Create";
            }
            else
            {
                ViewBag.Mode = "Edit";
            }
                return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (brand.Id == 0)
            {
                Uow.Brand.Add(brand);
            }
            else
            {         
                Brand BrandToUpdate = Uow.Brand.Get(brand.Id);
                BrandToUpdate.Name = brand.Name;
            }

            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Brand brand = Uow.Brand.Get(id);
            Uow.Brand.Remove(brand);
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }
    }
}