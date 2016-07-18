namespace Cashbox.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CashboxDbContext _dataContext = new CashboxDbContext();

        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            return new Repository<T>(_dataContext);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
