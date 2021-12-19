using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DQuiz.Database;
using DQuiz.Database.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Business.RepositoryFolder
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DQuizDbContext _ctx;

        public Repository(DQuizDbContext ctx)
        {
            _ctx = ctx;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAllQueryable(bool isReadOnly = false)
        {
            var tSet = _ctx.Set<T>();
            if (isReadOnly)
                tSet = (DbSet<T>)tSet.AsNoTracking();

            return tSet;
        }

        public List<T> GetAllList(bool isReadOnly = false)
        {
            var tSet = _ctx.Set<T>();
            if (isReadOnly)
                tSet = (DbSet<T>)tSet.AsNoTracking();

            return tSet.ToList();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate);
        }

        public T Insert(T item)
        {
            _ctx.Set<T>().Add(item);
            return item;
        }

        public List<T> Insert(List<T> items)
        {
            _ctx.Set<T>().AddRange(items);
            return items;
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().SingleOrDefault(predicate);
        }

        public void Attach(T item)
        {
            _ctx.Set<T>().Attach(item);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Any(predicate);
        }

        public List<T> GetAllList()
        {
            throw new NotImplementedException();
        }

       
    }
}
