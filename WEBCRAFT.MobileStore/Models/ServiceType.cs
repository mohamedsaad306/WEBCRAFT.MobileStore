using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public bool HasBalance { get; set; }
        public double Balance { get; set; }
    }
}