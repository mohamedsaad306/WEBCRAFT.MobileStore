using Advensco.EventManagement.Models;
using System.Web.Http;

namespace Advensco.EventManagement.Controllers
{
    public class BaseController : ApiController
    {
        // GET: Base
        private UnitOfWork _uow;
        public UnitOfWork UOW
        {
            get
            {
                if (_uow == null)
                    _uow = new UnitOfWork(new Entities());
                return _uow;
            }
        }



    }
}