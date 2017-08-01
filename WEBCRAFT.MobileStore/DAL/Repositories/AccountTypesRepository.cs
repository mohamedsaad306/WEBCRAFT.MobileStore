using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL.Repositories
{
    public class AccountTypesRepository : Repository<AccountType>, IAccountTypeRepository
    {
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }
        public AccountTypesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

    }
}