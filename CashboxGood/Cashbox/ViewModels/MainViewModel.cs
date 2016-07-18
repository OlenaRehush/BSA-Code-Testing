using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Cashbox.Framework;
using Cashbox.Services;

namespace Cashbox.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IDataLoadingService _dataLoadingService;
        private readonly IPurchaseService _purchaseService;

        private ObservableCollection<AccountViewModel> _accounts;
        private ObservableCollection<OrderViewModel> _ordersHistory;
        private ObservableCollection<ProductViewModel> _products;
        private ObservableCollection<ProductViewModel> _selectedProducts;
        private decimal _total;
        private decimal _discount;
        private decimal _totalAfterDiscount;
        private string _errorMessage;
        private AccountViewModel _selectedAccount;

        public MainViewModel(IDataLoadingService dataLoadingService, IPurchaseService purchaseService)
        {
            _dataLoadingService = dataLoadingService;
            _purchaseService = purchaseService;

            LoadAccountsCommand = new DelegateCommand(loadAccounts);
            LoadOrdersHistoryCommand = new DelegateCommand(loadOrdersHistory, canLoadOrdersHistory);
            LoadProductsCommand = new DelegateCommand(loadProducts);
            CalculateTotalsCommand = new DelegateCommand(calculateTotals, canCalculateTotals);
            PurchaseCommand = new DelegateCommand(purchase, canPurchase);
        }

        public ObservableCollection<AccountViewModel> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        public ObservableCollection<OrderViewModel> OrdersHistory
        {
            get { return _ordersHistory; }
            set { SetProperty(ref _ordersHistory, value); }
        }

        public ObservableCollection<ProductViewModel> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public ObservableCollection<ProductViewModel> SelectedProducts
        {
            get { return _selectedProducts; }
            set { SetProperty(ref _selectedProducts, value); }
        }

        public decimal Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        public decimal Discount
        {
            get { return _discount; }
            set { SetProperty(ref _discount, value); }
        }

        public decimal TotalAfterDiscount
        {
            get { return _totalAfterDiscount; }
            set { SetProperty(ref _totalAfterDiscount, value); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        public AccountViewModel SelectedAccount
        {
            get { return _selectedAccount; }
            set { SetProperty(ref _selectedAccount, value); }
        }

        public ICommand LoadAccountsCommand { get; private set; }

        public ICommand LoadOrdersHistoryCommand { get; private set; }

        public ICommand LoadProductsCommand { get; private set; }

        public ICommand CalculateTotalsCommand { get; private set; }

        public ICommand PurchaseCommand { get; private set; }

        private void loadAccounts(object parameter)
        {
            Accounts = new ObservableCollection<AccountViewModel>(_dataLoadingService.GetAccounts());
        }

        private void loadOrdersHistory(object parameter)
        {
            OrdersHistory = new ObservableCollection<OrderViewModel>(
                _dataLoadingService.GetAccountOrders(SelectedAccount.Id));
        }

        private bool canLoadOrdersHistory(object parameter)
        {
            return SelectedAccount != null;
        }

        private void loadProducts(object parameter)
        {
            Products = new ObservableCollection<ProductViewModel>(_dataLoadingService.GetProducts());
        }

        private void calculateTotals(object parameter)
        {
            var selectedProducts = ((IEnumerable<object>)parameter).Cast<ProductViewModel>();

            Total = _purchaseService.GetProductsTotal(selectedProducts);
            Discount = _purchaseService.GetDiscount(SelectedAccount.Id, Total);
            TotalAfterDiscount = _purchaseService.GetTotalAfterDiscount(Total, Discount);
        }

        private bool canCalculateTotals(object parameter)
        {
            return SelectedAccount != null && parameter != null;
        }

        private void purchase(object parameter)
        {
            ErrorMessage = null;

            var accountId = SelectedAccount.Id;
            var productIds = ((IEnumerable<object>)parameter).Cast<ProductViewModel>().Select(x => x.Id);

            try
            {
                _purchaseService.Purchase(accountId, productIds, TotalAfterDiscount);
            }
            catch (PurchaseException ex)
            {
                ErrorMessage = ex.Message;
            }

            // Refresh data in the grids and select the same account that was selected before.
            LoadAccountsCommand.Execute(null);
            SelectedAccount = Accounts.Single(x => x.Id == accountId);
            
            LoadOrdersHistoryCommand.Execute(null);
            LoadProductsCommand.Execute(null);
        }

        private bool canPurchase(object parameter)
        {
            return SelectedAccount != null && parameter != null && ((IEnumerable<object>)parameter).Any();
        }
    }
}