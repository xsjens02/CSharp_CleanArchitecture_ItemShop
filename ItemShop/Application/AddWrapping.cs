using ItemShop.Domain;
using ItemShop.InterfaceAdapter;

namespace ItemShop.Application
{
    public class AddWrapping
    {
        private IWrappingRepos _wrappingRepos;
        public AddWrapping(IWrappingRepos wrappingRepos)
        {
            this._wrappingRepos = wrappingRepos;
        }

        public Wrapping Execute(Order order)
        {
            return _wrappingRepos.Read(order);
        }
    }
}
