using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.DAL;
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
        public IEnumerable<ProductsHomeViewModel> Get()
        {

            var products = UOW.Products.GetAll();
            var brands = UOW.Category.GetAll();
            var partModels = UOW.Subcategory.GetAll();
            ProductsHomeViewModel vm = new ProductsHomeViewModel { Products = products.ToList(), Brands = brands.ToList(), PartModels = partModels.ToList() };
            yield return vm;
        }
      
        //TODO: Not needed, as we have Save(). and we will not use View Models in response. 
        // GET: api/ApiProduct/5
        [HttpGet]
        [Route("Edit")]
        public HttpResponseMessage Edit(int? id)
        {
            Product p = null;
            
            var brands = UOW.Category.GetAll();
            var Subcategory = UOW.Subcategory.GetAll();

            if (id != null)
            {
                p = UOW.Products.Get((int)id);
            }

            ProductViewModels vm = new ProductViewModels { product = p, Brands = brands.ToList(), PartModels = Subcategory.ToList() };
            UOW.Dispose();
             return Request.CreateResponse(HttpStatusCode.OK, vm);
        }

        // POST: api/ApiProduct
        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Product product)
        {
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
                product.Category = new Category { Id = product.FK_CategoryId };
                UOW.Products.Add(product);
            }
            UOW.Complete();
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //TODO: is this method Tested ? , what is the value? , why we have this method while we have Save ? 
        // PUT: api/ApiProduct/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiProduct/5
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int? id)
        {
            if(id==null)
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
