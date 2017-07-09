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

        public IBrandrepository Brand { get { return new BrandRepository(_context); } }

        public IPartModelRepository PartModel { get { return new PartModelRepository(_context); } }
        public ICustomerRepository Customers { get { return new CustomerRepository(_context); } }

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