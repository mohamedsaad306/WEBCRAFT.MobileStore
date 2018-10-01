using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class CategoryRepository:Repository<Category>,ICategoryepository
    {
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }
        public CategoryRepository(ApplicationDbContext context)
            :base(context)
        {

        }

    }
}