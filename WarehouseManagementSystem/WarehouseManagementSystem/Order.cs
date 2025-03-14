using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem
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

        public Order(decimal price, string name, string deliveryAddress, ClientTypes clientType, PaymentMethods paymentMethod, OrderStatuses orderStatus)
        {
            Price = price;
            Name = name;
            DeliveryAddress = deliveryAddress;
            ClientType = clientType;
            PaymentMethod = paymentMethod;
            OrderStatus = orderStatus;
        }

        public override string ToString()
            => $"Id: {Id} | Price: {Price.ToString("C")} | Name: {Name} | DeliveryAddress: {DeliveryAddress} | ClientType: {ClientType} | PaymentMethod: {PaymentMethod} | OrderStatus: {OrderStatus}";
    }
}
