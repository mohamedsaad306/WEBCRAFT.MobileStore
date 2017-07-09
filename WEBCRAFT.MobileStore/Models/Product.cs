using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int FK_BrandId { get; set; }
        public int FK_PartModelId { get; set; }
        public Brand Brand { get; set; }
        public PartModel PartModel { get; set; }
        public decimal SellPrice { get; set; }
 
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