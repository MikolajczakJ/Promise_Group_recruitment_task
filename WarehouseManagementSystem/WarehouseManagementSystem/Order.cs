using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem
{
    public enum ClientType
    {
        Individual,
        Company
    }
    public enum PaymentMethod
    {
        Cash,
        CreditCard
    }
    public enum OrderStatus
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
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string DeliveryAddress { get; set; }
        public ClientType ClientType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Order(decimal price, string name, string deliveryAddress, ClientType clientType, PaymentMethod paymentMethod, OrderStatus orderStatus)
        {
            Price = price;
            Name = name;
            DeliveryAddress = deliveryAddress;
            ClientType = clientType;
            PaymentMethod = paymentMethod;
            OrderStatus = orderStatus;
        }

        public override string ToString()
            => $"Price: {Price.ToString("C")} | Name: {Name} | DeliveryAddress: {DeliveryAddress} | ClientType: {ClientType} | PaymentMethod: {PaymentMethod} | OrderStatus: {OrderStatus}";
    }
}
