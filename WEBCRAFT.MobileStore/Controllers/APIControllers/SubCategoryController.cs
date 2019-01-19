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
    [RoutePrefix("api/SubCategory")]
    public class SubCategoryController : BaseController
    {
       
        // GET: Subcategory
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var partModels = UOW.Subcategory.GetAll();
          
            return Request.CreateResponse(HttpStatusCode.OK, partModels);
        }
        [HttpGet]
        [Route("Manage")]
        public HttpResponseMessage Manage(int? id)
        {
           
            Subcategory p = null;
            if (id != null)
            { 
                p = UOW.Subcategory.Get((int)id);
            }
            var brands = UOW.Category.GetAll();
            SubcategoryViewModel vm = new SubcategoryViewModel { Subcategory = p, Categories = brands.ToList() };
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK, vm);
        }

        [HttpPost]
        [Route("Manage")]
        public HttpResponseMessage Manage(Subcategory Subcategory)
        {
            if (Subcategory.Id != 0)
            {
                var pToUpdate = UOW.Subcategory.Get(Subcategory.Id);
                pToUpdate.Name = Subcategory.Name;
                pToUpdate.Fk_CategoryId = Subcategory.Fk_CategoryId;
            }
            else
            {
                UOW.Subcategory.Add(Subcategory);
            }
            UOW.Complete();
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK,Subcategory.Id);
        }

        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            Subcategory Subcategory = UOW.Subcategory.Get(id);
            UOW.Subcategory.Remove(Subcategory);
            UOW.Complete();
            UOW.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
