using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBCRAFT.MobileStore.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int FK_CustomerId { get; set; }

        public Decimal Total { get; set; }
        public decimal DueAmmount { get; set; }

        public InvoiceType Type { get; set; }
        public DateTime CreatedAt { get; set; }


    }
    public class InvoiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
