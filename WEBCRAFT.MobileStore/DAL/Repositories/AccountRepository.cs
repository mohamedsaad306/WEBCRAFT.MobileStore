using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        
        public AccountRepository(ApplicationDbContext context)
            :base(context)
        {
        }
    } 
}