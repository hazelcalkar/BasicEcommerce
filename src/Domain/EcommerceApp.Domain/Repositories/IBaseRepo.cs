﻿using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Repositories
{
    public interface IBaseRepo<T> where T : class , IBaseEntity
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);// ıd si bir olanı getir
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
        Task<bool> Any(Expression<Func<T, bool>> expression);//var mı yok mu
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null,
            Func<IQueryable<T>,IIncludableQueryable<T,object>> include =null);//ıquerayble ne bak 
        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
