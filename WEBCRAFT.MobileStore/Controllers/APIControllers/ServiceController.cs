using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Helper;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : BaseController
    {
        

       
        [HttpGet]
        [Route("NewServiceBalance")]
        public HttpResponseMessage NewServiceBalance()
        {
            List<ServiceBalance> servicesBalances = (List<ServiceBalance>)UOW.ServiceBalances.GetAll();
            var response = new Response<object>
            {
                Data = new { servicesBalances = servicesBalances },
                status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);

        }

        [HttpPost]
        [Route("NewServiceBalance")]

        public HttpResponseMessage NewServiceBalance(ServiceBalance serviceBalance)
        {
            ServiceBalance ServiceBalanceId = UOW.ServiceBalances.Add(serviceBalance);
            UOW.Complete();
            UOW.Dispose();
            var response = new Response<object>
            {
                Data = new { Id = ServiceBalanceId.Id },
                status = ResponseStatusEnum.sucess,
                StatusCode = HttpStatusCode.OK,
                Message = "sucess "
            };
            return Request.CreateResponse(response);

        }
    }
}
