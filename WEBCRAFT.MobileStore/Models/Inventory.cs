﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        //TODO: Why we have Events Here ?
        public List<Event> Events { get; set; }
    }

    public class InventoryProducts
    {
        public int Id { get; set; }
        public int Inventory_Id { get; set; }
        public int Product_Id { get; set; }
        //TODO: this model should preserve only the actual product quantity at the inventory, so the Event Id is not needed here. TBD
        public int Event_Id { get; set; }
        //TODO: Rename to quantity it's more relevant. 
        public int Amount { get; set; }

    }

}