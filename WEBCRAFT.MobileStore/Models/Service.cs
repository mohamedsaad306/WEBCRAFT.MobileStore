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
        public decimal Amount { get; set; }
        public bool HasExtraFees { get; set; }
        public string Comment { get; set; }
        public int ExtraFeesId { get; set; }
        public ExtraFeesType ExtraFeesType { get; set; }
        public int ServiceTypId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceBalenceId { get; set; }
        public ServiceBalance ServiceBalance { get; set; }

    }
    public class InvoicableServices
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public decimal SellPrice { get; set; }
        public int Count { get; set; }
    }
}