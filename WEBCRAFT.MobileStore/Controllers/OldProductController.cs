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
    public class OldProductController : Controller
    {
        public OldProductController()
          : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }

        public OldProductController(UnitOfWork u)
        {
            Uow = u;
        }
        public UnitOfWork Uow = new UnitOfWork(new ApplicationDbContext());// { get; set; }


        //
        // GET: /Product/
        public ActionResult Index()
        {
            var products = Uow.Products.GetAll();
            var brands = Uow.Category.GetAll();
            var partModels = Uow.Subcategory.GetAll();
            ProductsHomeViewModel vm = new ProductsHomeViewModel { Products = products.ToList(), Brands = brands.ToList(), PartModels = partModels.ToList() };
            return View(vm);
        }

        public ActionResult Edit(int? id)
        {
            Product p = null;
            ViewBag.Mode = "Create";
            var brands = Uow.Category.GetAll();
            var Subcategory = Uow.Subcategory.GetAll();

            if (id != null)
            {
                ViewBag.Mode = "Edit";
                p = Uow.Products.Get((int)id);
            }

            ProductViewModels vm = new ProductViewModels { product = p , Brands = brands.ToList() , PartModels = Subcategory.ToList()};
            Uow.Dispose();
            return View("Edit", vm);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.Id != 0)
            {
                var pToUpdate = Uow.Products.Get(product.Id);
                pToUpdate.Name = product.Name;
                pToUpdate.SellPrice = product.SellPrice;
               // pToUpdate.FK_CategoryId = product.FK_CategoryId;
                pToUpdate.FK_SubcategoryId = product.FK_SubcategoryId;
                
            }
            else
            {
               // product.Category = new Category { Id = product.FK_CategoryId };
                Uow.Products.Add(product);
            }
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            Product p = Uow.Products.Get(id);
            Uow.Products.Remove(p);
            Uow.Complete();
            Uow.Dispose();
            return RedirectToAction("Index");
        }

    }
}