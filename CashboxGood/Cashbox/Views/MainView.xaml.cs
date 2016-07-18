using Cashbox.DataAccess;
using Cashbox.Services;
using Cashbox.ViewModels;

namespace Cashbox.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();

            // It should be constructed using the IoC container.
            var unitOfWorkFactory = new UnitOfWorkFactory();
            var dataLoadingService = new DataLoadingService(unitOfWorkFactory);
            var purchaseService = new PurchaseService(unitOfWorkFactory);

            // Create and set manually to simplify the example.
            DataContext = new MainViewModel(dataLoadingService, purchaseService);
        }
    }
}