using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Domain
{
    public class Item : Order
    {
        private int _id;
        public string _description;
        public double _price;

        public Item(int id, string description, double price)
        {
            this._id = id;
            this._description = description;
            this._price = price;
        }
        public override string Description()
        {
            return this._description;
        }

        public override double Price()
        {
            return this._price;
        }
    }
}
