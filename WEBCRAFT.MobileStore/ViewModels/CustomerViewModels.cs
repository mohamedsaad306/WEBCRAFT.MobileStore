using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.ViewModels
{
    public class CustomerIndexViewModel
    {
        public List<Customer> Customers { get; set; }

    }
    public class CustomerEditViewModel
    {
        public Customer Customer { get; set; }
    }
}