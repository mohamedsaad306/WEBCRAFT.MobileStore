using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Helper;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseController
    {



        //TODO: How to use paging here?
        // GET: api/ApiProduct
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {

            var products = UOW.Products.GetAll();
            //var brands = UOW.Category.GetAll();
            //var partModels = UOW.Subcategory.GetAll();
            //ProductsHomeViewModel vm = new ProductsHomeViewModel { Products = products.ToList(), Brands = brands.ToList(), PartModels = partModels.ToList() };
            return Request.CreateResponse(HttpStatusCode.OK,products);
        }

       

        // POST: api/ApiProduct
        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Product product)
        {
            if(product.FK_CategoryId!=0)
            {
                var category = UOW.Category.Get(product.FK_CategoryId);
                if (category == null)
                {
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Category not found");
                }
            }

            if (product.Id != 0)
            {
               
                var pToUpdate = UOW.Products.Get(product.Id);
                pToUpdate.Name = product.Name;
                pToUpdate.SellPrice = product.SellPrice;
                pToUpdate.FK_CategoryId = product.FK_CategoryId;
                pToUpdate.FK_SubcategoryId = product.FK_SubcategoryId;

            }
            else
            {
                
                UOW.Products.Add(product);

            }
            UOW.Complete();
            UOW.Dispose();
            var response = new Response<object>
            {
                Data = new { Id = product.Id },
                status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message  ="sucess "
            };
            return Request.CreateResponse(response);
          //  return Request.CreateResponse(HttpStatusCode.OK,product.Id);
        }



        // DELETE: api/ApiProduct/5
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int? id)
        {
            if (id == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            Product p = UOW.Products.Get((int)id);
            UOW.Products.Remove(p);
            UOW.Complete();
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

      

    }
}
