using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBCRAFT.MobileStore.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Account ParentAccount { get; set; }
 
    }
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
