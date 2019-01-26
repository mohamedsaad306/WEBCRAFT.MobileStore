using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FK_CategoryId { get; set; }
        public int FK_SubcategoryId { get; set; }

        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public decimal SellPrice { get; set; }

        public string ImagePath { get; set; }
        public string Barcode { get; set; }
        public virtual  StockItem StockItems { get; set; }

        public List<InventoryPreservedProduct> InventoryPreservedProducts { get; set; }
        ////TODO: Please confirm that this navigation property will resolve to inventories containing this product not all inventories. 
        //[Key,ForeignKey("Inventory")]
        public List<Inventory> Inventories { get; set; }
        ////TODO: Same as above navigation Proeprty. 
        //public List<Event> Events { get; set; }
    }
    public class InvoicableProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal SellPrice { get; set; }
    }
}