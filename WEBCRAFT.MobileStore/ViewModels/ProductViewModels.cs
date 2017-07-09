using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class ProductViewModels
    {
        public Product product{ get; set; }

        //[Required]
        //[Display(Name="Product Name")]
        //public string ProductName { get; set; }

        //[Required]
        //[Display(Name = "Sell Price")]

        //public decimal sellPrice { get; set; }
    }
    public class ProductsHomeViewModel
    {
        public List<Product> Products { get; set; }
    }
}