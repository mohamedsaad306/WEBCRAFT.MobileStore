using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }

        public CustomerRepository(ApplicationDbContext _context) : base(_context)
        {
        }

    }
}