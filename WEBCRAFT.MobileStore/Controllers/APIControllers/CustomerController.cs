using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Helper;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : BaseController
    {
       

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
            var Customers = UOW.Customers.GetAll().ToList() ;
            var response = new Response<object>
            {
                Data = new { Customers = Customers },
                Status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);
        }
     


        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Customer customer)
        {
            if (customer != null)
            {
                var NewCustomer = CustomerRepository.AddNewCustomer(customer);
                var response = new Response<object>
                {
                    Data = new { Id = customer.Id },
                    Status = ResponseStatusEnum.sucess,
                    StatusCode = HttpStatusCode.OK,
                    Message = "sucess "
                };
                return Request.CreateResponse(response);
            }
            else
            {
                var response = new Response<object>
                {

                    Status = ResponseStatusEnum.error,
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Message = "sucess "
                };
                return Request.CreateResponse(response);
            }
                

        }
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            Customer customerToDelete = UOW.Customers.Get(id);
            UOW.Customers.Remove(customerToDelete);
            UOW.Complete();
            UOW.Dispose();
            var response = new Response<object>
            {
                
                Status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);
        }

     
    }
}
