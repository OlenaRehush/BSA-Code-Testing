using System.Collections.Generic;
using System.Linq;
using Cashbox.DataAccess;
using Cashbox.Models;
using Cashbox.ViewModels;

namespace Cashbox.Services
{
    internal class DataLoadingService : IDataLoadingService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DataLoadingService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<AccountViewModel> GetAccounts()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                return uow.Repository<Account>().All().Select(x => new AccountViewModel(x));
            }
        }

        public IEnumerable<OrderViewModel> GetAccountOrders(int accountId)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                return uow.Repository<Order>()
                          .Query()
                          .Where(x => x.AccountId == accountId)
                          .ToList()
                          .Select(x => new OrderViewModel(x));
            }
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                return uow.Repository<Product>().All().Select(x => new ProductViewModel(x));
            }
        }
    }
}