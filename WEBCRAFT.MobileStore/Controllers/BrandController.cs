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
        :this(new UnitOfWork(new ApplicationDbContext()))
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
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}