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
    [RoutePrefix("api/ApiProduct")]
    public class ApiProductController : ApiController
    {
        public ApiProductController()
         : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }

        public ApiProductController(UnitOfWork u)
        {
            Uow = u;
        }
        public UnitOfWork Uow = new UnitOfWork(new ApplicationDbContext());// { get; set; }




        // GET: api/ApiProduct
        [HttpGet]
        [Route("Get")]
        public IEnumerable<ProductsHomeViewModel> Get()
        {

            var products = Uow.Products.GetAll();
            var brands = Uow.Brand.GetAll();
            var partModels = Uow.PartModel.GetAll();
            ProductsHomeViewModel vm = new ProductsHomeViewModel { Products = products.ToList(), Brands = brands.ToList(), PartModels = partModels.ToList() };
            yield return vm;
        }

        // GET: api/ApiProduct/5
        [HttpGet]
        [Route("Edit")]
        public HttpResponseMessage Edit(int? id)
        {
            Product p = null;
            
            var brands = Uow.Brand.GetAll();
            var partModel = Uow.PartModel.GetAll();

            if (id != null)
            {
                
                p = Uow.Products.Get((int)id);
            }

            ProductViewModels vm = new ProductViewModels { product = p, Brands = brands.ToList(), PartModels = partModel.ToList() };
            Uow.Dispose();
             return Request.CreateResponse(HttpStatusCode.OK, vm);
        }

        // POST: api/ApiProduct
        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Product product)
        {
            if (product.Id != 0)
            {
                var pToUpdate = Uow.Products.Get(product.Id);
                pToUpdate.Name = product.Name;
                pToUpdate.SellPrice = product.SellPrice;
                pToUpdate.FK_CategoryId = product.FK_CategoryId;
                pToUpdate.FK_SubcategoryId = product.FK_SubcategoryId;

            }
            else
            {
                product.Category = new Category { Id = product.FK_CategoryId };
                Uow.Products.Add(product);
            }
            Uow.Complete();
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

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
            Product p = Uow.Products.Get((int)id);
            Uow.Products.Remove(p);
            Uow.Complete();
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
