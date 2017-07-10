using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }

        public InvoiceRepository(DbContext _context) : base(_context)
        {
        }

    }
}