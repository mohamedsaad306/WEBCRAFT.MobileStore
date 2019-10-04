using Advensco.EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Advensco.EventManagement.Controllers
{
    [RoutePrefix("api/Item")]
    public class ItemController : BaseController
    {

        [HttpPost, Route("Create")]
        public HttpResponseMessage Create(Item item)
        {
            Logger.Logger.Log("Message ");

            //throw  new  Exception("Post Exception ");

            item.Id = Guid.NewGuid();
            var createdItem = UOW.Items.Add(item);
            ///UOW.Complete();

            return Request.CreateResponse(new GenericResponse<object>
            {
                Data = createdItem.Id,
                Status = ResponseStatusEnum.sucess,
                Message = "Success", 
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }

        [HttpGet, Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            throw new Exception("Custom Exception ");
            var res = new GenericResponse<List<Item>>
            {
                Status = ResponseStatusEnum.sucess,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Success",
                //Data = UOW.Items.Get(includeProperties: $"{nameof(Item.Category)},{nameof(Item.SubCategory)}").ToList(),
                Data = UOW.Items.Get( ).ToList(),
            };
            return Request.CreateResponse(res);

        }
    }
}