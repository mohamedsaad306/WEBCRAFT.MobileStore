using Advensco.EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Advensco.EventManagement.Controllers
{
    public class EventController : BaseController
    {
        // GET: Event
        [HttpPost, Route("Create")]
        public HttpResponseMessage Create(Event eventToCraete)
        {
            eventToCraete.Id = Guid.NewGuid();
            var createdItem = UOW.Events.Add(eventToCraete);
            UOW.Complete();

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
            var res = new GenericResponse<List<Event>>
            {
                Status = ResponseStatusEnum.sucess,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Success",
                //Data = UOW.Items.Get(includeProperties: $"{nameof(Item.Category)},{nameof(Item.SubCategory)}").ToList(),
                Data = UOW.Events.Get().ToList(),
            };
            return Request.CreateResponse(res);
        }
    }
}