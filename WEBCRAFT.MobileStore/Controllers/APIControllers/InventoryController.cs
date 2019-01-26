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
    [RoutePrefix("api/Inventory")]
    public class InventoryController : BaseController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var inventories = UOW.inventories.GetAll();
            var response = new Response<object>
            {
                Data = new { inventories = inventories },
                status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);

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
                var response = new Response<object>
                {
                    Data = new { Id = inventory.Id },
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
