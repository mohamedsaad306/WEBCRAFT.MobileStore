using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.DAL.Repositories;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProductRepository Products { get { return new ProductRepository(_context); } }

        public ICategoryepository Brand { get { return new CategoryRepository(_context); } }

        public IServiceRepository Services { get { return new ServiceRepository(_context); } }
        public IServiceBalanceRepository ServiceBalances { get { return new ServiceBalanceRepository(_context); } }

        public ISubcategoryRepository PartModel { get { return new SubcategoryRepository(_context); } }
        public ICustomerRepository Customers { get { return new CustomerRepository(_context); } }

        public IAccountRepository Accounts { get { return new AccountRepository(_context); } }
        public IAccountTypeRepository AccountTypes { get { return new AccountTypesRepository(_context); } }


        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}