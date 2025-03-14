using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem
{
    public interface IOrderService
    {
        public void MainMenu();
    }

    public class OrderService: IOrderService
    {

        public void MainMenu()
        {
            var option = Menu.MultipleChoice("Choose an option:", "Create order", "Exit");
            switch (option)
            {
                case 0:
                    Order order = CreateOrder();
                    Console.WriteLine(order);
                    break;
            }
        }

        private Order CreateOrder()
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
            return newOrder;
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
