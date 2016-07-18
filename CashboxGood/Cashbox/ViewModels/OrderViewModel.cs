using System;
using Cashbox.Models;

namespace Cashbox.ViewModels
{
    internal class OrderViewModel
    {
        public OrderViewModel(Order order)
        {
            Date = order.Date;
            Total = order.Total;
        }

        public OrderViewModel()
        {
        }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}