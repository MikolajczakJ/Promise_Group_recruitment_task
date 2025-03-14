using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem
{

    public class OrderService
    {
        public void MainMenu()
        {
            int option;
            do
            {
                option = Menu.MultipleChoice("Choose an option:", "Create order", "Orders", "Exit");
            switch (option)
            {
                case 0:
                    if (AddOrder())
                        Console.WriteLine("Order added successfully");
                    else 
                        Console.WriteLine("Something went wrong");
                    break;
                case 1:
                    ListOrders(GetOrders());
                    break;
            }
            } while (option != 2);
        }

        private bool AddOrder()
        {
            Console.Write("Enter the price of the order:");
            decimal price = ParseDecimal(Console.ReadLine());
            Console.Write("Enter the name of the order:");
            string name = Console.ReadLine();
            Console.Write("Enter the delivery address:");
            string deliveryAddress = Console.ReadLine();
            ClientTypes clientType = (ClientTypes)Menu.MultipleChoice("Client type:","Individual","Company");
            PaymentMethods paymentMethod = (PaymentMethods)Menu.MultipleChoice("Payment method:","Cash","Credit card");
            var newOrder = new Order(price, name, deliveryAddress, clientType, paymentMethod, OrderStatuses.New);
            using(WarehouseDbContext dbContext = new WarehouseDbContext())
            {
                dbContext.Orders.Add(newOrder);
                return dbContext.SaveChanges()>0;
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            using (WarehouseDbContext dbContext = new WarehouseDbContext())
            {
                return dbContext.Orders.ToList();
            }
        }
        private void ListOrders(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }   

        private decimal ParseDecimal(string input)
        {
            decimal result;
            bool flag = decimal.TryParse(input, out result) && result > 0;
            while (!flag)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number greater than 0:");
                input = Console.ReadLine();
                flag = decimal.TryParse(input, out result) && result>0;
            }
            return result;
        }

    }
}
