using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.DAL.Repositories;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class PartModelRepository : Repository<PartModel> , IPartModelRepository
    {

        
        public PartModelRepository(ApplicationDbContext context)
            :base (context)
        {

        }
    }
}