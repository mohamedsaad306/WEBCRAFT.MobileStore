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
    [RoutePrefix("api/Category")]
    public class CategoryController : BaseController
    {

       

        // GET: api/ApiBrand
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var brands = UOW.Category.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, brands);

        }
        [HttpGet]
        [Route("Manage")]
        public HttpResponseMessage Manage(int? id)
        {
            Category b = null;
           
            if (id != null)
            {
               
                b = UOW.Category.Get((int)id);
            }
            
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK, b);
        }
        [HttpPost]
        [Route("Manage")]
        public HttpResponseMessage Manage(Category category)
        {
            try
            {
                if (category.Id == 0)
                {
                    UOW.Category.Add(category);
                }
                else
                {
                    Category BrandToUpdate = UOW.Category.Get(category.Id);
                    BrandToUpdate.Name = category.Name;
                }

                UOW.Complete();
                UOW.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK ,category.Id);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, e.Message);
            }
           
        }


        // DELETE: api/ApiBrand/5
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Category Category = UOW.Category.Get(id);
                UOW.Category.Remove(Category);
                UOW.Complete();
                UOW.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, e.Message);
            }
            
        }
    }
}
