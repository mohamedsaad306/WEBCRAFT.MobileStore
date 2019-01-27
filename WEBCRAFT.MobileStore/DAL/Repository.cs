using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WEBCRAFT.MobileStore.Models;

namespace WEBCRAFT.MobileStore.DAL
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext Context;
        public ApplicationDbContext AppContext { get { return Context as ApplicationDbContext; } }

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
}