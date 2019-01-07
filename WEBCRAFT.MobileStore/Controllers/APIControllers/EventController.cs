using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/Event")]
    public class EventController : BaseController
    {
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
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }

    }
}
