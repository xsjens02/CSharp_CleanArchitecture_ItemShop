using ItemShop.Domain;
using ItemShop.InterfaceAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Application
{
    public class PickItem
    {
        private IItemRepos _itemRepos;
        public PickItem(IItemRepos itemRepos)
        {
            this._itemRepos = itemRepos;
        }
        public Item Execute(int id)
        {
            return _itemRepos.Read(id);
        }
    }
}
