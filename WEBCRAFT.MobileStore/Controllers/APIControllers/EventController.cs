using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.Helper;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/Event")]
    public class EventController : BaseController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var events = UOW.Event.GetAll();

            var response = new Response<object>
            {
                Data = new { events = events },
                Status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Event myEvent)
        {
            try
            {
                if (myEvent.Id != 0)
                {
                    var pToUpdate = UOW.Event.Get(myEvent.Id);
                    pToUpdate.Address = myEvent.Address;
                    pToUpdate.Owner = myEvent.Owner;
                    pToUpdate.StartDate = myEvent.StartDate;
                    pToUpdate.EndDate = myEvent.EndDate;
                    //pToUpdate.Customer = myEvent.Customer != null ? myEvent.Customer : pToUpdate.Customer;
                    pToUpdate.FK_CustomerId=myEvent.FK_CustomerId;
                    UOW.Event.Update(pToUpdate);

                }
                else
                {

                    UOW.Event.Add(myEvent);

                }
                UOW.Complete();
                UOW.Dispose();
                var response = new Response<object>
                {
                    Data = new { Id = myEvent.Id },
                    Status = ResponseStatusEnum.sucess,
                    StatusCode = HttpStatusCode.OK,
                    Message = "sucess "
                };
                return Request.CreateResponse(response);
            }
            catch (Exception e)
            {

                var response = new Response<object>
                {
                    
                    Status = ResponseStatusEnum.error,
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Message = e.Message
                };
                return Request.CreateResponse(response);
            }

        }

    }
}
