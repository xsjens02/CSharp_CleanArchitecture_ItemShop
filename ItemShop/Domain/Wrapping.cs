using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Domain
{
    public class Wrapping : OrderDecorator
    {
        private string _description;
        private double _price;
        public Wrapping(Order order, string description, double price) : base(order)
        {
            this._description = description;
            this._price = price;
        }

        public override string Description()
        {
            return $"{this._order.Description()}\nWrapped with {this._description}";
        }

        public override double Price()
        {
            return this._order.Price() + this._price;
        }
    }
}
