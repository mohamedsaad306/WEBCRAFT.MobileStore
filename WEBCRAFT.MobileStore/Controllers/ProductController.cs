using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;
//using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
      //  :this(new UnitOfWork(new ApplicationDbContext()))
        {
        }

        //public ProductController(UnitOfWork u )
        //{
        //    Uow = u;
        //}
        public UnitOfWork Uow = new UnitOfWork(new ApplicationDbContext ());// { get; set; }


        //
        // GET: /Product/
        public ActionResult Index()
        {
            var products = Uow.Products.GetAll();
            ProductsHomeViewModel vm = new ProductsHomeViewModel { Products = products.ToList() };
            return View(vm);
        }

        public ActionResult Edit(int?  id)
        {
            Product p = null;
            if (id != null)
            { p = Uow.Products.Get((int)id); }
            
            ProductViewModels vm = new ProductViewModels { product = p };
            Uow.Dispose();            
            return View("Edit",vm);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.Id!=0)
            {
                var pToUpdate= Uow.Products.Get(product.Id);
                pToUpdate.Name = product.Name;
                pToUpdate.SellPrice = product.SellPrice;
            }
            else
            {
                Uow.Products.Add(product);
            }
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("index");
        }


    }
}