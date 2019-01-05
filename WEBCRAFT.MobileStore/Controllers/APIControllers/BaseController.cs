using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.Controllers

{
    public class BaseController : ApiController
    {
        private UnitOfWork _uow;
        public UnitOfWork UOW
        {
            get
            {
                if (_uow == null)
                    _uow = new UnitOfWork(new ApplicationDbContext());
                return _uow;
            }
        }
    }
}
