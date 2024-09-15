using ItemShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.InterfaceAdapter
{
    public interface IItemRepos
    {
        Item Read(int id);
        List<Item> ReadAll();
    }
}
