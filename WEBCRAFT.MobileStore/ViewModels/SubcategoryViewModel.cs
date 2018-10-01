using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class SubcategoryViewModel
    {
        public Subcategory PartModel { get; set; }


        [Required]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class SubcategoryHomeViewModel
    {
        public List<Category> Category { get; set; }
        public List<Subcategory> Subcategory { get; set; }
    }
}