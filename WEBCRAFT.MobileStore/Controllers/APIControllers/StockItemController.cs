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
    [RoutePrefix("api/StockItem")]
    public class StockItemController : BaseController
    {
        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(StockItem stockItem)
        {
            if((stockItem.InventoryId==0 ||stockItem.ProductId==0)|| (stockItem.InventoryId == 0 && stockItem.ProductId == 0))
            {
                var response = new Response<object>
                {
                    
                    status = ResponseStatusEnum.error,
                    StatusCode = HttpStatusCode.Conflict,
                    Message = "we can not create a stock without product and inventory"
                };
                return Request.CreateResponse(response);
                
            }
            var product = UOW.Products.Get(stockItem.ProductId);
            var inventory = UOW.inventories.Get(stockItem.InventoryId);
            if((product==null ||inventory==null)|| (product == null && inventory == null))
            {
                var response = new Response<object>
                {

                    status = ResponseStatusEnum.error,
                    StatusCode = HttpStatusCode.Conflict,
                    Message = "we can not create a stock without product and inventory"
                };
                return Request.CreateResponse(response);
            }
               
            try
            {
                if (stockItem.Id != 0)
                {
                    var pToUpdate = UOW.StockItem.Get(stockItem.Id);
                    pToUpdate.Quantity = stockItem.Quantity;
                    pToUpdate.ProductId = stockItem.ProductId;
                    pToUpdate.InventoryId = stockItem.InventoryId;
                    UOW.StockItem.Update(pToUpdate);

                }
                else
                {

                    UOW.StockItem.Add(stockItem);

                }
                UOW.Complete();
                UOW.Dispose();
                var response = new Response<object>
                {
                    Data = new { Id = stockItem.Id },
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
                    StatusCode = HttpStatusCode.Conflict,
                    Message = e.Message
                };
                return Request.CreateResponse(response);
            }

        }

    }
}
