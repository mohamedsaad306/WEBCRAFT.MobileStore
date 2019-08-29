using Advensco.EventManagement.Bll;
using Advensco.EventManagement.Models;
using System.Web.Http;

namespace Advensco.EventManagement.Controllers
{
    public class BaseController : ApiController
    {
        // GET: Base
        private UnitOfWork _uow;
        private WarehouseBll _bll; 
        public UnitOfWork UOW
        {
            get
            {
                if (_uow == null)
                    _uow = new UnitOfWork(new Entities());
                return _uow;
            }
        }

        public WarehouseBll WarehouseBll
        {
            get
            {
                if (_bll == null) _bll = new WarehouseBll(_uow);
                return _bll; 
            }
        }

    }
}