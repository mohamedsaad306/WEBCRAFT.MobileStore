using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBCRAFT.MobileStore.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public int FK_AccountId { get; set; } 
        public Decimal Ammount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }


    }
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
