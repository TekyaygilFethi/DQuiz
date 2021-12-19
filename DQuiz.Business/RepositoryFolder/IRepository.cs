using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DQuiz.Business.RepositoryFolder
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllQueryable(bool isReadOnly = false);
        List<T> GetAllList(bool isReadOnly = false);
        List<T> GetAllList();

        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        T Insert(T item);
        List<T> Insert(List<T> items);
        void Attach(T item);

        bool Any(Expression<Func<T, bool>> predicate);
    }
}
