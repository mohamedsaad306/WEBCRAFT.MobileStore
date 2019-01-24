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
    [RoutePrefix("api/Category")]
    public class CategoryController : BaseController
    {

       

        // GET: api/ApiBrand
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var brands = UOW.Category.GetAll();
            var response = new Response<object>
            {
                Data = new { brands = brands. },
                status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);

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
            var response = new Response<object>
            {
                Data = new { Category = b },
                status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);
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
                var response = new Response<object>
                {
                    Data = new { Id = category.Id },
                    status = ResponseStatusEnum.sucess,
                    StatusCode = HttpStatusCode.OK,
                    Message = "sucess "
                };
                return Request.CreateResponse(response);
            }
            catch (Exception e)
            {

                var response = new Response<object>
                {
                    
                    status = ResponseStatusEnum.error,
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Message = e.Message
                };
                return Request.CreateResponse(response);
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
                var response = new Response<object>
                {
                    
                    status = ResponseStatusEnum.sucess,
                    StatusCode = HttpStatusCode.OK,
                    Message = "sucess "
                };
                return Request.CreateResponse(response);
            }
            catch (Exception e)
            {

                var response = new Response<object>
                {
                    
                    status = ResponseStatusEnum.error,
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Message = e.Message
                };
                return Request.CreateResponse(response);
            }
            
        }
    }
}
