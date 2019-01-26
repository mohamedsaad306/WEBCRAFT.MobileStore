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

        public ICategoryepository Category { get { return new CategoryRepository(_context); } }

        public IServiceRepository Services { get { return new ServiceRepository(_context); } }
        public IServiceBalanceRepository ServiceBalances { get { return new ServiceBalanceRepository(_context); } }

        public ISubcategoryRepository Subcategory { get { return new SubcategoryRepository(_context); } }
        public ICustomerRepository Customers { get { return new CustomerRepository(_context); } }

        public IAccountRepository Accounts { get { return new AccountRepository(_context); } }
        public IAccountTypeRepository AccountTypes { get { return new AccountTypesRepository(_context); } }
        public IStockItemRepository StockItem { get { return new StockItemRepository(_context); } }
        public IInventoryPreservedProductRepository InventoryPreservedProduct { get { return new InventoryPreservedProductRepository(_context); } }
        public IInventoryRepository inventories { get { return new InventoryRepository(_context); } }
        public IEventRepository Event { get { return new EventRepository(_context); } }


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