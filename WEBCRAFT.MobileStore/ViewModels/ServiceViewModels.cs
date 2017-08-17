using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class IndexServiceViewModel
    {
        public List<Service> Services { get; set; }
    }
    public class ServiceBalanceIndex
    {
        public ServiceBalance ServiceBalance { get; set; }
        public List<ServiceBalance> ServiceBalances { get; set; }

    }
}