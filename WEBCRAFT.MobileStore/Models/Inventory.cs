using System;
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
    }

    public class InventoryProducts
    {
        public int Inventory_Id { get; set; }
        public int Product_Id { get; set; }
        public int Amount { get; set; }

    }



}