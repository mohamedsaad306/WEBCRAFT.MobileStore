using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.DAL.Repositories;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class SubcategoryRepository : Repository<Subcategory> , ISubcategoryRepository
    {

        
        public SubcategoryRepository(ApplicationDbContext context)
            :base (context)
        {

        }
    }
}