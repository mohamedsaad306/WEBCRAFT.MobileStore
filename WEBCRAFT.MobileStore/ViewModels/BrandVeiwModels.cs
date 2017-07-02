using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class BrandVeiwModels
    {
        public Brand Brand { get; set; }
        

        [Required]
        [Display (Name ="Brand Name")]
        public String BrandName { get; set; }
    }
    public class BrandsHomeViewModel
    {
        public List<Brand> Brands { get; set; }
    }
}