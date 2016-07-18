using Cashbox.Framework;
using Cashbox.Models;

namespace Cashbox.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        private int _amount;

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Title = product.Title;
            Price = product.Price;
            _amount = product.Amount;
        }

        public ProductViewModel()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
    }
}