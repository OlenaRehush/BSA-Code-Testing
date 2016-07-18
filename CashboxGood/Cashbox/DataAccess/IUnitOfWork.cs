using System;

namespace Cashbox.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;
        void SaveChanges();
    }
}
