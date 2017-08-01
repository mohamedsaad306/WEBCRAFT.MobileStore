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

        public Account ParentAccount { get; set; }
        public int FK_ParentAccountId { get; set; }

        public AccountType Type { get; set; }
        public int FK_TypeId { get; set; }

        public List<Transaction> Transactions { get; set; }

        public int PartnerId { get; internal set; }

        public const int SalesAccount = 1;
        public const int PurchacesAccount = 2;
        public const int CustomersAccount = 3;
        public const int ExpensesAccount = 4;
    }
    public class AccountType
    {

        public  const int SalesType = 1;
        public  const int PurchacesType = 2;
        public  const int CustomersType = 3;
        public const int ExpensesType = 4;

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
