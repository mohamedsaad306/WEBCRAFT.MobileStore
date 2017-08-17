using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository():base(new ApplicationDbContext())
        {
        }

        public CustomerRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public Customer AddNewCustomer(Customer c)
        {
            // add customer's account 
            c.Account = new Account
            {
                Name = c.Name,
                FK_TypeId = AccountType.CustomersType,
                FK_ParentAccountId = Account.CustomersAccount,
                ParentAccount = uow.Accounts.Find(a => a.Id == Account.CustomersAccount).FirstOrDefault(),
                Type = uow.AccountTypes.Find(t => t.Id == AccountType.CustomersType).FirstOrDefault()
            };

            Customer newCustomer = uow.Customers.Add(c);
            uow.Complete();

            uow.Accounts.Find(a => a.Id == newCustomer.Account.Id).First().PartnerId = newCustomer.Id;
            newCustomer.FK_AccountId = newCustomer.Account.Id;

            uow.Complete();
            uow.Dispose();

            return newCustomer;
        }
    }
}