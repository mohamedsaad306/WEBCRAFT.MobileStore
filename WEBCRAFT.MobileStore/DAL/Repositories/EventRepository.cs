using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        
        public EventRepository(ApplicationDbContext context)
            :base(context)
        {
        }
    } 
}