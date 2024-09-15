using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Domain
{
    public abstract class Order
    {
        public abstract string Description();
        public abstract double Price();
    }
}
