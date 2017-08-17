using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class ServiceBalanceRepository : Repository<ServiceBalance>, IServiceBalanceRepository
    {
        public ServiceBalanceRepository():this(new ApplicationDbContext ())
        {
        }
        public ServiceBalanceRepository(ApplicationDbContext _context) : base(_context)
        {   
        }
    }
}