﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int FK_CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
        public Customer Customer { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<Product> Products { get; set; }
       
    }
}