using ItemShop.Application;
using ItemShop.Domain;
using ItemShop.Infrastructure;

namespace ItemShop.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiating persistence file paths
            string itemFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistence\Items.txt");
            string wrappingFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistence\Wrapping.txt");
            string shipmentFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistence\Shipment.txt");

            //instantiating application use cases 
            ShowItems showItems = new ShowItems(new ItemFileAdapter(itemFilePath));
            PickItem pickItem = new PickItem(new ItemFileAdapter(itemFilePath));
            AddWrapping addWrapping = new AddWrapping(new WrappingFileAdapter(wrappingFilePath));
            AddShipment addShipment = new AddShipment(new ShipmentFileAdapter(shipmentFilePath));
            ViewOrder viewOrder = new ViewOrder();

            //instansiating user order
            Order order;

            //executing use case; show items 
            showItems.Execute();

            //prompt user to select an item for order
            int itemVal = 0;
            do
            {
                Console.WriteLine("\nChoose what item you would like from 1-5:");
                string? itemInput = Console.ReadLine();
                if (itemInput != null && CanConvertToInt(itemInput))
                    itemVal = int.Parse(itemInput);
            } while (1 > itemVal || itemVal > 5);

            //executing use case; pick item 
            order = pickItem.Execute(itemVal);

            //prompt user to select if order to be wrapped
            Console.WriteLine("\nWould you like the item to be wrapped? type 1 to accept:");
            string? wrappedInput = Console.ReadLine();
            int wrapVal = 0;
            if (wrappedInput != null && CanConvertToInt(wrappedInput))
                wrapVal = int.Parse(wrappedInput);

            //executing use case; add wrapping 
            if (wrapVal == 1)
                order = addWrapping.Execute(order);
            
            //prompt user to select if order to be shipped 
            Console.WriteLine("\nWould you like the item to be shipped? type 1 to accept:");
            string? shipmentInput = Console.ReadLine();
            int shipmentVal = 0;
            if (shipmentInput != null && CanConvertToInt(shipmentInput))
                shipmentVal = int.Parse(shipmentInput);
            
            //executing use case; add shipment
            if (shipmentVal == 1)
                order = addShipment.Execute(order);

            Console.WriteLine();

            //executing use case; view order
            viewOrder.Execute(order);
        }

        /// <summary>
        /// chekcs if a string can be parsed to an integer
        /// </summary>
        /// <param name="str">string to check if possible to convert to integer</param>
        /// <returns>true if possible to convert string to integer, false if not</returns>
        static bool CanConvertToInt(string str)
        {
            try
            {
                int test = int.Parse(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
