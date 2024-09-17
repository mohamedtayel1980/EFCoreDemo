using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain
{
    public class Order
    {
        private DateOnly _orderDate;  // Backing field for OrderDate

        public int OrderId { get; set; }

        public DateOnly OrderDate
        {
            get => _orderDate;
            set
            {
                if (value <= DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentException("Order date must be greater than today's date.");
                }
                _orderDate = value;
            }
        }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
