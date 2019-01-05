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
    [RoutePrefix("api/ApiBrand")]
    public class ApiBrandController : ApiController
    {

        public ApiBrandController()
       : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }
        public ApiBrandController(UnitOfWork u)
        {
            Uow = u;
        }
        public UnitOfWork Uow { get; set; }

        // GET: api/ApiBrand
        [HttpGet]
        [Route("Get")]
        public IEnumerable<CategoriesHomeViewModel> Get()
        {
            var brands = Uow.Brand.GetAll();
            var viewModel = new CategoriesHomeViewModel { Categories = brands.ToList() };
            yield return viewModel;
        }
        [HttpGet]
        [Route("Manage")]
        public CategoryVeiwModels Manage(int? id)
        {
            Category b = null;
           
            if (id != null)
            {
               
                b = Uow.Brand.Get((int)id);
            }
            CategoryVeiwModels bVM = new CategoryVeiwModels { Category = b };
            Uow.Dispose();
            return  bVM;
        }
        [HttpPost]
        [Route("Manage")]
        public HttpResponseMessage Manage(Category category)
        {
            if (category.Id == 0)
            {
                Uow.Brand.Add(category);
            }
            else
            {
                Category BrandToUpdate = Uow.Brand.Get(category.Id);
                BrandToUpdate.Name = category.Name;
            }

            Uow.Complete();
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // DELETE: api/ApiBrand/5
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            Category brand = Uow.Brand.Get(id);
            Uow.Brand.Remove(brand);
            Uow.Complete();
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
