using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Helpers;

namespace WarehouseManagementSystem
{

    public class OrderService
    {
        public bool AddOrder()
        {
            OrderStatuses orderStatus = OrderStatuses.New;
            decimal price;
            string name, deliveryAddress;
            ClientTypes clientType;
            PaymentMethods paymentMethod;
            
            price = ValueParser.ParseDecimal("Enter the price of the order:");
            Console.Write("Enter the name of the order:");
            name = Console.ReadLine();
            Console.Write("Enter the delivery address:");
            deliveryAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(deliveryAddress))
                orderStatus = OrderStatuses.Error;
            
            clientType = (ClientTypes)MenuHelper.MultipleChoice("Client type:","Individual","Company");
            paymentMethod = (PaymentMethods)MenuHelper.MultipleChoice("Payment method:","Cash","Credit card");
            var newOrder = new Order(price, name, deliveryAddress, clientType, paymentMethod, orderStatus);
            using(WarehouseDbContext dbContext = new WarehouseDbContext())
            {
                dbContext.Orders.Add(newOrder);
                return dbContext.SaveChanges()>0;
            }
        }

        public bool UpdateOrderStatus(OrderStatuses orderStatus)
        {
            ListOrders(GetOrders());
            int id = ValueParser.ParseInt("Enter the Id of the order:");
            using (WarehouseDbContext dbContext = new WarehouseDbContext())
            {
                var order = dbContext.Orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    Console.WriteLine("Order not found");
                    return false;
                }
                if (orderStatus == OrderStatuses.InWarehouse && order.Price>=2500 && order.PaymentMethod == PaymentMethods.Cash)
                {
                    order.OrderStatus = OrderStatuses.Returned;
                    Console.WriteLine($"Order Price is greater or equal to 2500 ({order.Price:C}), order status has been set to \"Returned to client \"\n Press enter to proceed");
                    Console.ReadLine();
                }
                else
                    order.OrderStatus = orderStatus;
                return dbContext.SaveChanges() > 0;
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            using (WarehouseDbContext dbContext = new WarehouseDbContext())
                return dbContext.Orders.ToList();
        }
        public void ListOrders(IEnumerable<Order> orders)
        {
            if (orders.Count()==0)
                Console.WriteLine("There are no orders in the database");
            else
            {
                foreach (var order in orders)
                    Console.WriteLine(order);
            }
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }   
    }
}
