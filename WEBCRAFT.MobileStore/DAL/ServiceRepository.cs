using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.DAL.Repositories;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class ServiceRepository:Repository<Service>,IServiceRepository
    {
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }


        public ServiceRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public IEnumerable<Service> GetServices()
        {
            return AppContext.Services.ToList();

        }


    }
}