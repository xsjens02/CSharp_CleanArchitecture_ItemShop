using ItemShop.Domain;
using ItemShop.InterfaceAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Infrastructure
{
    public class WrappingFileAdapter : IWrappingRepos
    {
        private StreamReader _reader;
        public WrappingFileAdapter(string filepath)
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
        public Wrapping Read(Order order)
        {
            using (_reader)
            {
                string? line;
                while ((line = _reader.ReadLine()) != null)
                {
                    String[] parts = line.Split('|');

                    string description = parts[0];
                    double price = double.Parse(parts[1]);

                    return new Wrapping(order, description, price);
                }
            }
            throw new InvalidOperationException("No shipment data found in file");
        }
    }
}
