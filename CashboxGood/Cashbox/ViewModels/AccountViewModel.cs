using Cashbox.Framework;
using Cashbox.Models;

namespace Cashbox.ViewModels
{
    internal class AccountViewModel : BaseViewModel
    {
        private decimal _balance;

        public AccountViewModel(Account account)
        {
            Id = account.Id;
            Name = account.Name;
            _balance = account.Balance;
        }

        public AccountViewModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance
        {
            get { return _balance; }
            set { SetProperty(ref _balance, value); }
        }
    }
}