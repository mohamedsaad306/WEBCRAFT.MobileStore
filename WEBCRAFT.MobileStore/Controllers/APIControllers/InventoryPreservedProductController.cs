using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/InventoryPreservedProduct")]
    public class InventoryPreservedProductController : BaseController
    {
        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(InventoryPreservedProduct preservedProduct)
        {
            try
            {
                if (preservedProduct.Id != 0)
                {
                    //TBD
                    //var stock = UOW.StockItem.Find(item => item.Inventory_Id == preservedProduct.InventoryId && preservedProduct.ProductId == item.Product_Id).SingleOrDefault();

                    //var pToUpdate = UOW.InventoryPreservedProduct.Get(preservedProduct.Id);

                    ////preservedProduct.PreservedQuantity>=pToUpdate.PreservedQuantity? 

                    //UOW.InventoryPreservedProduct.Update(pToUpdate);

                }
                else
                {
                    var stocks = UOW.StockItem.Find(item => preservedProduct.ProductId == item.Product_Id && item.Quantity != 0).OrderByDescending(q => q.Quantity).ToList();
                    var totalQuantity = stocks.Sum(q => q.Quantity);//total quanlity in all inventorie
                    if (stocks.Count != 0)
                    {
                        foreach (var stock in stocks)
                        {
                            if (preservedProduct.PreservedQuantity > totalQuantity)
                                return Request.CreateResponse(HttpStatusCode.Conflict, "We do not have enough quantity,so please do not exceed this number " + totalQuantity);
                            else if (stock.Quantity >= preservedProduct.PreservedQuantity)
                            {
                                stock.Quantity -= preservedProduct.PreservedQuantity;
                                preservedProduct.InventoryId = stock.Inventory_Id;
                                UOW.StockItem.Update(stock);
                                UOW.InventoryPreservedProduct.Add(preservedProduct);
                                break;
                            }
                            else if (stock.Quantity <= preservedProduct.PreservedQuantity)
                            {
                                preservedProduct.PreservedQuantity -= stock.Quantity;
                                var newPreservedProduct = new InventoryPreservedProduct
                                {
                                    EventId = preservedProduct.EventId,
                                    InventoryId = stock.Inventory_Id,
                                    ProductId = preservedProduct.ProductId,
                                    PreservedQuantity= stock.Quantity
                                };
                                stock.Quantity = 0;
                               
                                UOW.StockItem.Update(stock);
                               
                                UOW.InventoryPreservedProduct.Add(newPreservedProduct);
                                UOW.Complete();
                            }

                        }


                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.Conflict, "the product does not exist in our inventories");

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
