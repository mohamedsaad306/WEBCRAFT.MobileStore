using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class BrandRepository:Repository<Brand>,IBrandrepository
    {
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }
        public BrandRepository(ApplicationDbContext context)
            :base(context)
        {

        }

    }
}