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

        public InvoiceStatus InvoiceStatus { get; set; }
        // list of Related items 
        public List<InvoicableProduct> InvoicedProducts { get; set; }
        public List<InvoicableServices> InvoicedServices { get; set; }
    }

    public class InvoiceStatus
    {
        public int Id { get; set; }
        public string State { get; set; }        
    }

    // sales invoice || procurement invoice 
    public class InvoiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
