using ItemShop.Domain;
using ItemShop.InterfaceAdapter;

namespace ItemShop.Infrastructure
{
    public class ItemFileAdapter : IItemRepos
    {
        private StreamReader _reader;
        public ItemFileAdapter(string filepath)
        {
            try
            {
                _reader = new StreamReader(filepath);
            }
            catch (FileNotFoundException)  
            {
                throw new FileNotFoundException("item file path incorrect");
            }
        }
        public Item Read(int id)
        {
            using (_reader)
            {
                string? line;
                while ((line = _reader.ReadLine()) != null)
                {
                    String[] parts = line.Split('|');
                    if (int.TryParse(parts[0], out int itemID))
                    {
                        if (itemID == id)
                        {
                            string description = parts[1];
                            double price = double.Parse(parts[2]);

                            return new Item(itemID, description, price);
                        }
                    }
                }
            }
            throw new KeyNotFoundException($"Item with ID {id} was not found.");
        }

        public List<Item> ReadAll()
        {
            List<Item> list = new List<Item>();
            using (_reader)
            {
                string? line;
                while ((line = _reader.ReadLine()) != null)
                {
                    String[] parts = line.Split('|');

                    int id = int.Parse(parts[0]);
                    string description = parts[1];
                    double price = double.Parse(parts[2]);

                    list.Add(new Item(id, description, price));
                }
            }
            return list;
        }
    }
}
