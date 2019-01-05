using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL.Repositories
{
    public class InventoryProductRepository : Repository<InventoryProducts>, IInventoryProductRepository

    {
        public InventoryProductRepository(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}