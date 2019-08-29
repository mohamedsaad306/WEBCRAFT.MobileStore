using Advensco.EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Advensco.EventManagement.Controllers
{
    public class WarehouseController : BaseController
    {

        [HttpPost, Route("Create")]
        public HttpResponseMessage Create(Warehouse _Warehouse)
        {
            _Warehouse.Id = Guid.NewGuid();
            var createdWarehouse = UOW.Warehouses.Add(_Warehouse);
            UOW.Complete();

            return Request.CreateResponse(new GenericResponse<object>
            {
                Data = createdWarehouse.Id,
                Status = ResponseStatusEnum.sucess,
                Message = "Success",
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }

        [HttpGet, Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var res = new GenericResponse<List<Warehouse>>
            {
                Status = ResponseStatusEnum.sucess,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Success",
                Data = UOW.Warehouses.Get().ToList(),
            };
            return Request.CreateResponse(res);

        }
    }
}