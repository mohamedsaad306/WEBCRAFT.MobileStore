using Advensco.EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advensco.EventManagement.Bll
{
    public class BaseBll
    {
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
        public BaseBll(UnitOfWork uow )
        {
            _uow = uow; 
        }

    }
}