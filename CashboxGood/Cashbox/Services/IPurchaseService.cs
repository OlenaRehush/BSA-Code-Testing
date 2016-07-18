using System.Collections.Generic;
using Cashbox.Models;
using Cashbox.ViewModels;

namespace Cashbox.Services
{
    internal interface IPurchaseService
    {
        decimal GetOrdersHistoryTotal(int accountId);
        decimal GetProductsTotal(IEnumerable<ProductViewModel> products);
        decimal GetProductsTotal(IEnumerable<Product> products);
        decimal GetDiscount(int accountId, decimal productsTotal);
        decimal GetTotalAfterDiscount(decimal total, decimal discount);
        void Purchase(int accountId, IEnumerable<int> productIds, decimal total);
    }
}