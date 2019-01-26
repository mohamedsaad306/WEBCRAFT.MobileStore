using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual StockItem StockItems { get; set; }
       
        public List<Product> Products { get; set; }
        //TODO: Why we have Events Here ?
        //public List<Event> Events { get; set; }
    }

    public class StockItem
    {
        public int Id { get; set; }
        //[Key, Column(Order = 0), ForeignKey("StockItems")]
        public int InventoryId { get; set; }

        //[Key, Column(Order = 1),ForeignKey("StockItems")]
        public int ProductId { get; set; }
        //TODO: this model should preserve only the actual product quantity at the inventory, so the Event Id is not needed here. TBD
        //public int Event_Id { get; set; }
        //TODO: Rename to quantity it's more relevant. 
        public int Quantity { get; set; }

    }

}