using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.BLL
{
    public static class CustomersBLL
    {
        public static int AddNewCustomer(UnitOfWork uow, Customer c)
        {
            
            // add customer 
            c.Account = new Account
            {
                Name = c.Name,
                FK_TypeId = AccountType.CustomersType,
                FK_ParentAccountId = Account.CustomersAccount,
                ParentAccount = uow.Accounts.Find(a => a.Id == Account.CustomersAccount).FirstOrDefault(),
                Type = uow.AccountTypes.Find(t => t.Id == AccountType.CustomersType).FirstOrDefault()
            };
            
            Customer newC = uow.Customers.Add(c);
            c.Account.PartnerId = newC.Id;
            c.FK_AccountId = newC.Account.Id;

            uow.Complete();            
            uow.Dispose();

            return newC.Id;
        }
    }
}