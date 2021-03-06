﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WEBCRAFT.MobileStore.DAL
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetPagination(int Page, int CountPerPage);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predecate);

        TEntity Add (TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove (TEntity entitie);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}