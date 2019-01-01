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
    [RoutePrefix("api/ApiPartModel")]
    public class ApiPartModelController : ApiController
    {
        public ApiPartModelController()
        : this(new UnitOfWork(new ApplicationDbContext()))
        {
        }
        public ApiPartModelController(UnitOfWork u)
        {
            Uow = u;
        }
        public UnitOfWork Uow { get; set; }
        // GET: PartModel
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var partModels = Uow.PartModel.GetAll();
            var brands = Uow.Brand.GetAll();
            SubcategoryHomeViewModel vm = new SubcategoryHomeViewModel { Subcategory = partModels.ToList(), Category = brands.ToList() };
            return Request.CreateResponse(HttpStatusCode.OK,vm);
        }
        [HttpGet]
        [Route("Manage")]
        public HttpResponseMessage Manage(int? id)
        {
           
            Subcategory p = null;
            if (id != null)
            {
               
                p = Uow.PartModel.Get((int)id);
            }
            var brands = Uow.Brand.GetAll();
            SubcategoryViewModel vm = new SubcategoryViewModel { PartModel = p, Categories = brands.ToList() };
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK, vm);
        }

        [HttpPost]
        [Route("Manage")]
        public HttpResponseMessage Manage(Subcategory partModel)
        {
            if (partModel.Id != 0)
            {
                var pToUpdate = Uow.PartModel.Get(partModel.Id);
                pToUpdate.Name = partModel.Name;
                pToUpdate.Fk_CategoryId = partModel.Fk_CategoryId;
            }
            else
            {
                Uow.PartModel.Add(partModel);
            }
            Uow.Complete();
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {
            Subcategory partModel = Uow.PartModel.Get(id);
            Uow.PartModel.Remove(partModel);
            Uow.Complete();
            Uow.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
