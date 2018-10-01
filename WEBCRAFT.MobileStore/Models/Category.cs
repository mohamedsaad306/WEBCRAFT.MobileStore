using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WEBCRAFT.MobileStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }

    }
}
