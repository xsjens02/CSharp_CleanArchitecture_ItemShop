using ItemShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Application
{
    public class ViewOrder
    {
        public void Execute(Order order)
        {
            Console.WriteLine($"You have ordered:\n{order.Description()}");
            Console.WriteLine($"At the price of:\n{order.Price()}$$");
        }
    }
}
