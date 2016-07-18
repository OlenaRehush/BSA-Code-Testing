using System.Collections.Generic;
using Cashbox.ViewModels;

namespace Cashbox.Services
{
    internal interface IDataLoadingService
    {
        IEnumerable<AccountViewModel> GetAccounts();
        IEnumerable<OrderViewModel> GetAccountOrders(int accountId);
        IEnumerable<ProductViewModel> GetProducts();
    }
}