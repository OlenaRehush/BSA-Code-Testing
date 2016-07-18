namespace Cashbox.DataAccess
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
