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
        public int AccountId { get; set; } 
        public decimal Ammount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TypeId { get; set; }
        public TransactionType Type { get; set; }
    }


    // incomming to account || outgoing from account 
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
