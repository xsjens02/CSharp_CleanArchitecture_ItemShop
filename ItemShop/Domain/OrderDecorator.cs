using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Domain
{
    public abstract class OrderDecorator : Order
    {
        public Order _order;

        public OrderDecorator(Order order)
        {
            this._order = order;
        }
    }
}
