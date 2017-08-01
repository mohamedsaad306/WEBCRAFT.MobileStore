using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBCRAFT.MobileStore.BLL;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {
            uow = new UnitOfWork(new ApplicationDbContext());
        }

        private UnitOfWork uow;

        // GET: Customer
        public ActionResult Index()
        {
            CustomerIndexViewModel vm = new CustomerIndexViewModel() { Customers = uow.Customers.GetAll().ToList() };
            return View(vm);
        }
        public ActionResult New()
        {
            return View("_New");
        }

        [HttpPost]
        public ActionResult Save(Customer Customer)
        {
            int CustomerID = CustomersBLL.AddNewCustomer(uow, Customer);


            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            Customer customerToDelete= uow.Customers.Get(id);
            uow.Customers.Remove(customerToDelete);
            uow.Complete();
            uow.Dispose();
            return RedirectToAction("Index");
        }
    }
}