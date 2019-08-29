﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Advensco.EventManagement.Models
{
    using System;
    using System.Collections.Generic;//repo
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;//repo

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventItem> EventItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemsOperation> ItemsOperations { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }
    }
    //repo interface 
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetPagination(int Page, int CountPerPage);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predecate);
        IQueryable<TEntity> GetAllToSort();
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entitie);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        IQueryable<TEntity> OrderBy(Expression<Func<TEntity, object>> exp);
        IEnumerable<TEntity> Get(
Expression<Func<TEntity, bool>> filter = null,
Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
string includeProperties = "");

    }
    //repo class 
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Entities AppContext { get { return Context as Entities; } }

        private UnitOfWork _uow;
        public UnitOfWork uow
        {
            get
            {
                if (_uow == null)
                    _uow = new UnitOfWork(AppContext);
                return _uow;
            }
        }

        public Repository(DbContext _context)
        {
            Context = _context;
        }

        public TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public virtual IEnumerable<TEntity> Get(
       Expression<Func<TEntity, bool>> filter = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
       string includeProperties = "")
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public IQueryable<TEntity> GetAllToSort()
        {
            return Context.Set<TEntity>();
        }
        public IQueryable<TEntity> OrderBy(Expression<Func<TEntity, object>> exp)
        {
            return Context.Set<TEntity>().OrderBy(exp);
        }
        public IEnumerable<TEntity> GetPagination(int Page = 0, int CountPerPage = 10)
        {
            return Context.Set<TEntity>().Skip(Page * CountPerPage).Take(CountPerPage).ToList();
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predecate)
        {
            return Context.Set<TEntity>().Where(predecate).ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

    }
    //end repo 

    // UOW 
    public class UnitOfWork
    {
        // public  CategoryRepository Categories { get { return new  CategoryRepository(_context); } }  

        public C__MigrationHistoryRepository C__MigrationHistory { get { return new C__MigrationHistoryRepository(_context); } }
        public AspNetRoleRepository AspNetRoles { get { return new AspNetRoleRepository(_context); } }
        public AspNetUserClaimRepository AspNetUserClaims { get { return new AspNetUserClaimRepository(_context); } }
        public AspNetUserLoginRepository AspNetUserLogins { get { return new AspNetUserLoginRepository(_context); } }
        public AspNetUserRepository AspNetUsers { get { return new AspNetUserRepository(_context); } }
        public CategoryRepository Categories { get { return new CategoryRepository(_context); } }
        public EventRepository Events { get { return new EventRepository(_context); } }
        public EventItemRepository EventItems { get { return new EventItemRepository(_context); } }
        public ItemRepository Items { get { return new ItemRepository(_context); } }
        public ItemsOperationRepository ItemsOperations { get { return new ItemsOperationRepository(_context); } }
        public SubCategoryRepository SubCategories { get { return new SubCategoryRepository(_context); } }
        public sysdiagramRepository sysdiagrams { get { return new sysdiagramRepository(_context); } }
        public SystemLogRepository SystemLogs { get { return new SystemLogRepository(_context); } }
        public WarehouseRepository Warehouses { get { return new WarehouseRepository(_context); } }
        public WarehouseItemRepository WarehouseItems { get { return new WarehouseItemRepository(_context); } }

        private readonly Entities _context;
        public UnitOfWork(Entities context)
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