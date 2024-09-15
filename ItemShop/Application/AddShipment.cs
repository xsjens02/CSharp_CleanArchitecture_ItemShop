using ItemShop.Domain;
using ItemShop.InterfaceAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Application
{
    public class AddShipment
    {
        private IShipmentRepos _shipmentRepos;
        public AddShipment(IShipmentRepos shipmentRepos)
        {
            this._shipmentRepos = shipmentRepos;
        }
        public Shipment Execute(Order order)
        {
            return _shipmentRepos.Read(order);
        }
    }
}
