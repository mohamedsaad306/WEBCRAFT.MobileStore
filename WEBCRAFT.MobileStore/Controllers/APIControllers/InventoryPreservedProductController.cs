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
                    var stocks = UOW.StockItem.Find(item => item.ProductId == preservedProduct.ProductId)
                        .OrderByDescending(q => q.Quantity).ToList();

                    var pToUpdate = UOW.InventoryPreservedProduct.Find(item => item.EventId == preservedProduct.EventId && item.ProductId == preservedProduct.ProductId);
                    var oldPreservedQuantity = pToUpdate.Sum(oldEvent => oldEvent.PreservedQuantity);
                    if (preservedProduct.PreservedQuantity > oldPreservedQuantity)
                    {
                        pToUpdate.OrderBy(q => q.PreservedQuantity).ToList();
                        var totalRemaningQuantities = stocks.Sum(stock => stock.Quantity);
                        var newQuantities = preservedProduct.PreservedQuantity - oldPreservedQuantity;
                        if (stocks.Count != 0)
                        {
                            foreach (var stock in stocks)
                            {
                                if (preservedProduct.PreservedQuantity > totalRemaningQuantities)
                                {
                                    var response = new Response<object>
                                    {

                                        Status = ResponseStatusEnum.error,
                                        StatusCode = HttpStatusCode.Conflict,
                                        Message = "We do not have enough quantity,so please do not exceed this number " + totalRemaningQuantities
                                    };
                                    return Request.CreateResponse(response);
                                }
                                else if (stock.Quantity >= preservedProduct.PreservedQuantity)
                                {
                                    stock.Quantity -= preservedProduct.PreservedQuantity;
                                    preservedProduct.InventoryId = stock.InventoryId;
                                    UOW.StockItem.Update(stock);
                                    var preservedQuantityToUpdate = UOW.InventoryPreservedProduct.Get(stock.InventoryId);
                                    if (preservedQuantityToUpdate != null)
                                    {
                                        preservedQuantityToUpdate.PreservedQuantity += totalRemaningQuantities;
                                        UOW.InventoryPreservedProduct.Update(preservedQuantityToUpdate);
                                        UOW.Complete();
                                    }
                                    else
                                    {
                                        preservedQuantityToUpdate = new InventoryPreservedProduct
                                        {
                                            EventId = preservedProduct.EventId,
                                            InventoryId = stock.InventoryId,
                                            ProductId = preservedProduct.ProductId,
                                            PreservedQuantity = totalRemaningQuantities
                                        };
                                        UOW.InventoryPreservedProduct.Add(preservedQuantityToUpdate);
                                        UOW.Complete();
                                    }

                                    UOW.Complete();
                                    break;
                                }
                                else if (stock.Quantity <= preservedProduct.PreservedQuantity)
                                {
                                    preservedProduct.PreservedQuantity -= stock.Quantity;
                                    var newPreservedProduct = UOW.InventoryPreservedProduct.Get(stock.InventoryId);
                                    if (newPreservedProduct != null)
                                    {
                                        newPreservedProduct.PreservedQuantity += stock.Quantity;
                                        UOW.InventoryPreservedProduct.Update(newPreservedProduct);
                                        UOW.Complete();
                                    }
                                    else
                                    {
                                        newPreservedProduct = new InventoryPreservedProduct
                                        {
                                            EventId = preservedProduct.EventId,
                                            InventoryId = stock.InventoryId,
                                            ProductId = preservedProduct.ProductId,
                                            PreservedQuantity = stock.Quantity
                                        };
                                        UOW.InventoryPreservedProduct.Add(newPreservedProduct);
                                        UOW.Complete();
                                    }
                                    stock.Quantity = 0;

                                    UOW.StockItem.Update(stock);


                                    UOW.Complete();
                                }
                            }
                        }

                    }
                    else if (preservedProduct.PreservedQuantity < oldPreservedQuantity)
                    {
                        var returnedQuantity = oldPreservedQuantity - preservedProduct.PreservedQuantity;
                        pToUpdate.OrderBy(q => q.PreservedQuantity).ToList();
                        foreach (var item in pToUpdate)
                        {
                            var inventory = UOW.StockItem.Get(item.InventoryId);
                            if (returnedQuantity > item.PreservedQuantity)
                            {
                                returnedQuantity -= item.PreservedQuantity;
                                inventory.Quantity += item.PreservedQuantity;
                                item.PreservedQuantity = 0;

                                UOW.InventoryPreservedProduct.Update(item);
                                UOW.StockItem.Update(inventory);

                            }
                            else
                            {

                                inventory.Quantity += returnedQuantity;

                                item.PreservedQuantity -= returnedQuantity;
                                returnedQuantity = 0;
                                UOW.InventoryPreservedProduct.Update(item);
                                UOW.StockItem.Update(inventory);

                            }
                        }
                    }
                    else
                    {
                        foreach (var item in pToUpdate)
                        {
                            var inventory = UOW.StockItem.Get(item.InventoryId);
                            inventory.Quantity += item.PreservedQuantity;
                            item.PreservedQuantity = 0;
                            UOW.InventoryPreservedProduct.Update(item);
                            UOW.StockItem.Update(inventory);

                        }

                    }






                }
                else
                {
                    var stocks = UOW.StockItem.Find(item => preservedProduct.ProductId == item.ProductId && item.Quantity != 0).OrderByDescending(q => q.Quantity).ToList();
                    var totalQuantity = stocks.Sum(q => q.Quantity);//total quanlity in all inventorie
                    if (stocks.Count != 0)
                    {
                        foreach (var stock in stocks)
                        {
                            if (preservedProduct.PreservedQuantity > totalQuantity)
                            {
                                var response = new Response<object>
                                {

                                    Status = ResponseStatusEnum.error,
                                    StatusCode = HttpStatusCode.Conflict,
                                    Message = "We do not have enough quantity,so please do not exceed this number " + totalQuantity
                                };
                                return Request.CreateResponse(response);
                            }
                            else if (stock.Quantity >= preservedProduct.PreservedQuantity)
                            {
                                stock.Quantity -= preservedProduct.PreservedQuantity;
                                preservedProduct.InventoryId = stock.InventoryId;
                                UOW.StockItem.Update(stock);
                                UOW.InventoryPreservedProduct.Add(preservedProduct);
                                UOW.Complete();
                                break;
                            }
                            else if (stock.Quantity <= preservedProduct.PreservedQuantity)
                            {
                                preservedProduct.PreservedQuantity -= stock.Quantity;
                                var newPreservedProduct = new InventoryPreservedProduct
                                {
                                    EventId = preservedProduct.EventId,
                                    InventoryId = stock.InventoryId,
                                    ProductId = preservedProduct.ProductId,
                                    PreservedQuantity = stock.Quantity
                                };
                                stock.Quantity = 0;

                                UOW.StockItem.Update(stock);

                                UOW.InventoryPreservedProduct.Add(newPreservedProduct);
                                UOW.Complete();
                            }

                        }


                    }
                    else
                    {
                        var response = new Response<object>
                        {

                            Status = ResponseStatusEnum.error,
                            StatusCode = HttpStatusCode.Conflict,
                            Message = "the product does not exist in our inventories"
                        };
                        return Request.CreateResponse(response);

                    }
                       

                }
                UOW.Complete();
                UOW.Dispose();
                var response1 = new Response<object>
                {
                   
                    Status = ResponseStatusEnum.sucess,
                    StatusCode = HttpStatusCode.OK,
                    Message = "sucess "
                };
                return Request.CreateResponse(response1);
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
