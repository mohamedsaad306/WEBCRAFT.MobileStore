using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCRAFT.MobileStore.DAL.Repositories;

namespace WEBCRAFT.MobileStore.DAL
{

    interface IUnitOfWork : IDisposable
    {
         IProductRepository Products { get; }
        int Complete();
    }
}
