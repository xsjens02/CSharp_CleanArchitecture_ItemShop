using ItemShop.Domain;
using ItemShop.InterfaceAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Application
{
    public class ShowItems
    {
        private IItemRepos _itemRepos;
        public ShowItems(IItemRepos itemRepos)
        {
            this._itemRepos = itemRepos;
        }

        public void Execute()
        {
            List<Item> itemList = _itemRepos.ReadAll();
            foreach (Item item in itemList)
                Console.WriteLine($"{item.Description()} -- price: {item.Price()}$$");
        }
    }
}
