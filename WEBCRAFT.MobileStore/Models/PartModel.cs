using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBCRAFT.MobileStore.Models
{
   public class PartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fk_BrandId { get; set; }

    }
}
