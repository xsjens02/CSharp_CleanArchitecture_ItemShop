using ItemShop.Domain;
using ItemShop.InterfaceAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemShop.Infrastructure
{
    internal class ShipmentFileAdapter : IShipmentRepos
    {
        private StreamReader _reader;
        public ShipmentFileAdapter(string filepath)
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
        public Shipment Read(Order order)
        {
            using (_reader)
            {
                string? line;
                while ((line = _reader.ReadLine()) != null)
                {
                    String[] parts = line.Split('|');

                    string description = parts[0];
                    double price = double.Parse(parts[1]);

                    return new Shipment(order, description, price);
                }
            }
            throw new InvalidOperationException("No shipment data found in file");
        }
    }
}
