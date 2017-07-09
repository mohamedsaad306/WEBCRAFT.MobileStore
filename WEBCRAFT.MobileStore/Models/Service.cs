using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Amount { get; set; }
        public bool HasExtraFees { get; set; }
        public string Comment { get; set; }
        public int FK_ExtraFeesId { get; set; }
        public ExtraFeesType ExtraFeesType { get; set; }
        public int FK_ServiceTypId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int FK_ServiceBalenceId { get; set; }
        public ServiceBalance ServiceBalance { get; set; }

    }
}