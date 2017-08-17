using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.DAL;

namespace WEBCRAFT.MobileStore.BLL
{
    public class BLL
    {
        private UnitOfWork _uow;
        public UnitOfWork uow { get { return _uow; } }

        public BLL (UnitOfWork uow)
        {
            this._uow = uow;
        }

    }
}