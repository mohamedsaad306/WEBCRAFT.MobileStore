using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext _context)
            : base(_context)
        {
        }
    }
}