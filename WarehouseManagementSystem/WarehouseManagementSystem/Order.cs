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
        InMagazine,
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
    }
}
