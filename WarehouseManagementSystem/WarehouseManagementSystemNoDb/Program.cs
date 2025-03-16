namespace WarehouseManagementSystemNoDb
{
    internal class Program
    {
        private static List<Order> orders = new List<Order>();
        private static int orderCounter = 1;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSelect option:");
                Console.WriteLine("1. Create new order");
                Console.WriteLine("2. Move order to the warehouse");
                Console.WriteLine("3. Move order to delivery");
                Console.WriteLine("4. Order list");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateOrder();
                        break;
                    case "2":
                        ProcessOrderToWarehouse();
                        break;
                    case "3":
                        ProcessOrderToShipment();
                        break;
                    case "4":
                        DisplayOrders();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                        break;
                }
            }
        }

        static void CreateOrder()
        {
            decimal price;
            string productName, deliveryAddress;
            ClientTypes clientType;
            OrderStatuses orderStatus = OrderStatuses.New;
            PaymentMethods paymentMethod;
            int clientTypeInt, paymentMethodInt;
            
            Console.Write("Name of the order: ");
            productName = Console.ReadLine();

            Console.Write("Price of the order: ");
            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
                Console.Write("Wrong value, please insert price that is greater than 0: ");

            Console.Write("Client type(Individual(0)/Company(1)): ");
            while (!int.TryParse(Console.ReadLine(),out clientTypeInt) || (clientTypeInt != 1 && clientTypeInt !=0))
                Console.Write("Please write down proper value, \n0 for Individual client\n1 for Company: ");
            clientType = (ClientTypes)clientTypeInt;
            

            Console.Write("Delivery address: ");
            deliveryAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(deliveryAddress))
                orderStatus = OrderStatuses.Error;
            

            Console.Write("Payment method (0 for cash, 1 for credit card: ");
            while (!int.TryParse(Console.ReadLine(), out paymentMethodInt) || (paymentMethodInt != 1 && paymentMethodInt != 0))
                Console.Write("Please write down proper value, \n0 for cash client\n1 for credit card: ");
            
            paymentMethod = (PaymentMethods)paymentMethodInt;
            orders.Add(new Order(orderCounter++,price, productName, deliveryAddress, clientType, paymentMethod, orderStatus));
            Console.WriteLine("Order has been created.");
        }
        static void ProcessOrderToWarehouse()
        {
            DisplayOrders();
            Console.Write("Order id: ");
            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                var order = orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                    order.ProcessToWarehouse();
                else
                    Console.WriteLine("Order not found.");
            }
        }

        static void ProcessOrderToShipment()
        {
            DisplayOrders();
            Console.Write("Order id: ");
            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                var order = orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                    order.ProcessToShipment();
                else
                    Console.WriteLine("Order not found.");
            }
        }
        static void DisplayOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders were found.");
                return;
            }
            foreach (var order in orders)
                Console.WriteLine(order);
        }

    }
}
