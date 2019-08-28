//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;//Comment
    using System.Collections.Generic;//repo
    using System.Data.Entity;//repo
    using System.Linq.Expressions;//repo
    using System.Linq;
    
    public partial class event_mgmtEntities : DbContext
    {
        public event_mgmtEntities()
            : base("name=event_mgmtEntities")
        {
    //Comment 
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventItem> EventItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemsOperation> ItemsOperations { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }
    }
    //end class 
    //start repo 
    //repo interface 
    public interface IRepository<TEntity> where TEntity : class 
        {
            TEntity Get(int id);
            IEnumerable<TEntity> GetAll();
            IEnumerable<TEntity> GetPagination(int Page, int CountPerPage);
            IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predecate);
            IQueryable<TEntity> GetAllToSort();
            TEntity Add (TEntity entity);
            void AddRange(IEnumerable<TEntity> entities);
            void Remove (TEntity entitie);
            void RemoveRange(IEnumerable<TEntity> entities);
            void Update(TEntity entity);
            IQueryable<TEntity> OrderBy(Expression<Func<TEntity, object>> exp);
    
        }
    
    //repo class 
    public class Repository<TEntity> :IRepository<TEntity> where TEntity:class
        {
            protected readonly DbContext Context;
            public event_mgmtEntities AppContext { get { return Context as event_mgmtEntities; } }
    
            private UnitOfWork _uow;
            public UnitOfWork uow { get
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
    
            public TEntity Get(int id)
            {
                return Context.Set<TEntity>().Find(id);
            }
    
            public IEnumerable<TEntity> GetAll()
            {
                return Context.Set<TEntity>().ToList();
            }
            public IQueryable<TEntity> GetAllToSort()
            {
                return Context.Set<TEntity>();
            }
            public IQueryable<TEntity>OrderBy(Expression<Func<TEntity, object>> exp)
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
           public  void Update(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
    
        }
    //end repo 
    // UOW 
    public class UnitOfWork  
        {
    
    	 public  CategoryRepository Categories { get { return new  CategoryRepository(_context); } }
    	 public  EventRepository Events { get { return new  EventRepository(_context); } }
    	 public  EventItemRepository EventItems { get { return new  EventItemRepository(_context); } }
    	 public  ItemRepository Items { get { return new  ItemRepository(_context); } }
    	 public  ItemsOperationRepository ItemsOperations { get { return new  ItemsOperationRepository(_context); } }
    	 public  SubCategoryRepository SubCategories { get { return new  SubCategoryRepository(_context); } }
    	 public  sysdiagramRepository sysdiagrams { get { return new  sysdiagramRepository(_context); } }
    	 public  WarehouseRepository Warehouses { get { return new  WarehouseRepository(_context); } }
    	 public  WarehouseItemRepository WarehouseItems { get { return new  WarehouseItemRepository(_context); } }
    
            private readonly event_mgmtEntities _context;
            public UnitOfWork(event_mgmtEntities context)
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
