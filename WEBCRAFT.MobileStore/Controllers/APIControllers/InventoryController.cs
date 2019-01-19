using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : BaseController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var inventories = UOW.inventories.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, inventories);

        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Inventory inventory)
        {
            try
            {
                if (inventory.Id != 0)
                {
                    var pToUpdate = UOW.inventories.Get(inventory.Id);
                    pToUpdate.Name = inventory.Name;
                    UOW.inventories.Update(pToUpdate);

                }
                else
                {

                    UOW.inventories.Add(inventory);

                }
                UOW.Complete();
                UOW.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK,inventory.Id);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.ExpectationFailed,e.Message);
            }
            
        }

    }
}
