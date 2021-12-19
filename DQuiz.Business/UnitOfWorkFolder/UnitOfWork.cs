using System;
using DQuiz.Business.RepositoryFolder;
using DQuiz.Database;
using DQuiz.Database.DbContexts;

namespace DQuiz.Business.UnitOfWorkFolder
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DQuizDbContext _ctx;

        public UnitOfWork(DQuizDbContext ctx)
        {
            _ctx = ctx;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return (IRepository<TEntity>)Activator.CreateInstance(typeof(Repository<TEntity>), new object[] { _ctx });
        }

        public void Save()
        {
            using (var ctxTransaction = _ctx.Database.BeginTransaction())
            {
                try
                {
                    _ctx.SaveChanges();

                    ctxTransaction.Commit();
                }
                catch (Exception ex)
                {
                    ctxTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
