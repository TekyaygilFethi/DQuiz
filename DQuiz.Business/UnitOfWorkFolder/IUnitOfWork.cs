using System;
using DQuiz.Business.RepositoryFolder;

namespace DQuiz.Business.UnitOfWorkFolder
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
