using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/ApiCustomer")]
    public class ApiCustomerController : ApiController
    {
        public ApiCustomerController()
        {
            uow = new UnitOfWork(new ApplicationDbContext());
        }

        private UnitOfWork uow;

        public CustomerRepository CustomerRepository
        {
            get
            {
                return new CustomerRepository();
            }
        }
        // GET: Customers
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            CustomerIndexViewModel vm = new CustomerIndexViewModel() { Customers = uow.Customers.GetAll().ToList() };
            return Request.CreateResponse(HttpStatusCode.OK,vm);
        }
     


        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Customer Customer)
        {
            Customer NewCustomer = CustomerRepository.AddNewCustomer(Customer);
            if (Customer != null)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
           
        }
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            Customer customerToDelete = uow.Customers.Get(id);
            uow.Customers.Remove(customerToDelete);
            uow.Complete();
            uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

     
    }
}
