using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.Controllers
{
    //[Route("api/Test")]
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {

        public Product Index()
        {
            return new Product
            {
                Category = new Category { Id = 1, Name = "category " },
                Id = 2,
                Name = "Product Name ",

            };
        }



        [HttpGet]
        [Route("getProduct")]
        public Product getProduct()
        {
            return new Product
            {
                Category = new Category { Id = 1, Name = "category " },
                Id = 2,
                Name = "Product Name ",

            };
        }
        [HttpPost]
        [Route("createProduct")]
        public object createProduct(Product _toCreate )
        {
            return new { sucess = true };
        }
    }
}
