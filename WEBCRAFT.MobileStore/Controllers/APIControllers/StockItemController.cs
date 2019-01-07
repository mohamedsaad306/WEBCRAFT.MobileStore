using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            try
            {
                if (stockItem.Id != 0)
                {
                    var pToUpdate = UOW.StockItem.Get(stockItem.Id);
                    pToUpdate.Quantity = stockItem.Quantity;
                    pToUpdate.Product_Id = stockItem.Product_Id;
                    pToUpdate.Inventory_Id = stockItem.Inventory_Id;
                    UOW.StockItem.Update(pToUpdate);

                }
                else
                {

                    UOW.StockItem.Add(stockItem);

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
