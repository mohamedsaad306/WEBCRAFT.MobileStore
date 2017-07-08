using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class PartModelViewModel
    {
        public PartModel PartModel { get; set; }


        [Required]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }
        public List<Brand> Brands { get; set; }
    }
    public class PartModelHomeViewModel
    {
      public   List<PartModel> PartModel { get; set; }
    }
}