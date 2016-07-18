using System.Collections.Generic;
using Cashbox.DataAccess;

namespace Cashbox.Models
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Balance { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
