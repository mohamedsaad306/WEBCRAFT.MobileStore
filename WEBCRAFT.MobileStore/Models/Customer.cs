using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBCRAFT.MobileStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name="Customer NAme Here ")]
        public string Name { get; set; }
        public Account Account { get; set; }
        public int FK_AccountId { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Event> Events { get; set; }

    }
}