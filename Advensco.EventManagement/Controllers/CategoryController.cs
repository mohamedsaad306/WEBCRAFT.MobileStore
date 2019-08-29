using Advensco.EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Advensco.EventManagement.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : BaseController
    { 
        [HttpGet, Route("Details/{id}")]
        public HttpResponseMessage Details(Guid id)
        {

            return   Request.CreateResponse(new GenericResponse<Category> {
                StatusCode = System.Net.HttpStatusCode.OK,
                Status = ResponseStatusEnum.sucess, 
                Data = UOW.Categories.Get(id), 
                Message= "Success", 
            }); 
        }
        [HttpGet, Route("GetAll")]
        public HttpResponseMessage  GetAll()
        {
            var res = new GenericResponse<List<Category>>
            {
                Status = ResponseStatusEnum.sucess,
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = UOW.Categories.GetAll().ToList(),
            };
            return Request.CreateResponse(res); 
             
        }
        // GET: Category/Create
        [HttpPost]
        public HttpResponseMessage Create(Category category)
        {
            category.Id = Guid.NewGuid();
            var createdCat = UOW.Categories.Add(category);
            UOW.Complete();
            return Request.CreateResponse( new GenericResponse<object> {Data = createdCat.Id,Status = ResponseStatusEnum.sucess, StatusCode = System.Net.HttpStatusCode.OK});
        }
    }
}
