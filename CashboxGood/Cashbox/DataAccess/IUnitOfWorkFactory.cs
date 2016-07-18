namespace Cashbox.DataAccess
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
