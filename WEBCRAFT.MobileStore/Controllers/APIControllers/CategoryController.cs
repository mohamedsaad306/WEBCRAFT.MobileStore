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
    [RoutePrefix("api/Category")]
    public class CategoryController : BaseController
    {

       

        // GET: api/ApiBrand
        [HttpGet]
        [Route("Get")]
        public IEnumerable<CategoriesHomeViewModel> Get()
        {
            var brands = UOW.Category.GetAll();
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
               
                b = UOW.Category.Get((int)id);
            }
            CategoryVeiwModels bVM = new CategoryVeiwModels { Category = b };
            UOW.Dispose();
            return  bVM;
        }
        [HttpPost]
        [Route("Manage")]
        public HttpResponseMessage Manage(Category category)
        {
            if (category.Id == 0)
            {
                UOW.Category.Add(category);
            }
            else
            {
                Category BrandToUpdate = UOW.Category.Get(category.Id);
                BrandToUpdate.Name = category.Name;
            }

            UOW.Complete();
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // DELETE: api/ApiBrand/5
        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            Category Category = UOW.Category.Get(id);
            UOW.Category.Remove(Category);
            UOW.Complete();
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
