using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class CategoryVeiwModels
    {
        public Category Category { get; set; }
        

        [Required]
        [Display (Name ="Category Name")]
        public string CategoryName { get; set; }
    }
    public class CategoriesHomeViewModel
    {
        public List<Category> Categories { get; set; }
    }
}