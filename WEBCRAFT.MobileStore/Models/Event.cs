using System;
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
        public List<InventoryPreservedProduct> InventoryPreservedProducts { get; set; }
        //TODO: Replace with list of new model InventoryPreservedProducts.
        //public List<Inventory> Inventories { get; set; }
        ////TODO: Replace with list of new model InventoryPreservedProducts.
        //public List<Product> Products { get; set; }
    }
    //TODO: Add model InventoryPreservedProducts with info [productId, InventoryId, preservedQuantity ]

    public class InventoryPreservedProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public int EventId { get; set; }
        public int PreservedQuantity { get; set; }

    }
}