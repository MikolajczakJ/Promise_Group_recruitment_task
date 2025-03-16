using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemNoDb
{
    public enum ClientTypes
    {
        Individual,
        Company
    }
    public enum PaymentMethods
    {
        Cash,
        CreditCard
    }
    public enum OrderStatuses
    {
        New,
        InWarehouse,
        InDelivery,
        Returned,
        Error,
        Closed
    }
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string DeliveryAddress { get; set; }
        public ClientTypes ClientType { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public OrderStatuses OrderStatus { get; set; }

        public Order(int id,decimal price, string name, string deliveryAddress, ClientTypes clientType, PaymentMethods paymentMethod, OrderStatuses orderStatus)
        {
            Id = id;    
            Price = price;
            Name = name;
            DeliveryAddress = deliveryAddress;
            ClientType = clientType;
            PaymentMethod = paymentMethod;
            OrderStatus = orderStatus;
        }

        public override string ToString()
            => $"Id: {Id} | Price: {Price.ToString("C")} | Name: {Name} | DeliveryAddress: {DeliveryAddress} | ClientType: {ClientType} | PaymentMethod: {PaymentMethod} | OrderStatus: {OrderStatus}";


        public void ProcessToWarehouse()
        {
            if (Price >= 2500 && PaymentMethod == PaymentMethods.Cash)
            {
                OrderStatus = OrderStatuses.Returned;
                Console.WriteLine($"Order has been returned to the client( {Price} >= 2500 zł, payment with cash).");
            }
            else if (string.IsNullOrEmpty(DeliveryAddress))
            {
                OrderStatus = OrderStatuses.Error;
                Console.WriteLine("Delivery address is empty.");
            }
            else
            {
                OrderStatus = OrderStatuses.InWarehouse;
                Console.WriteLine("Order moved to the warehouse.");
            }
        }

        public void ProcessToShipment()
        {
            if (OrderStatus != OrderStatuses.InWarehouse)
            {
                Console.WriteLine("Order must be in warehouse before shipment");
                return;
            }
            OrderStatus = OrderStatuses.InDelivery;
            Console.WriteLine("Order is in delivery, wait 3 seconds...");

            Thread.Sleep(3000);
            OrderStatus = OrderStatuses.Closed;
            Console.WriteLine("Order has been delivered and closed.");
        }
    }
}
