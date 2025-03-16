using Xunit;
using WarehouseManagementSystemNoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemNoDb.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_Should_Be_Returned_When_Cash_On_Delivery_And_Amount_Too_High()
        {
            // Arrange
            var order = new Order(1, 3000, "Test", "ul. Testowa 1", ClientTypes.Individual, PaymentMethods.Cash, OrderStatuses.New);

            // Act
            order.ProcessToWarehouse();

            // Assert
            Xunit.Assert.Equal(OrderStatuses.Returned, order.OrderStatus);
        }


        [Fact]
        public void Order_Should_Fail_When_No_Shipping_Address()
        {
            // Arrange
            var order = new Order(1,500, "Test", "", ClientTypes.Individual, PaymentMethods.CreditCard, OrderStatuses.New);

            // Act
            order.ProcessToWarehouse();

            // Assert
            Xunit.Assert.Equal(OrderStatuses.Error, order.OrderStatus);
        }

        [Fact]
        public void Order_Should_Change_Status_To_InWarehouse_When_Valid()
        {
            // Arrange
            var order = new Order(1,1000, "Test", "ul. Testowa 1", ClientTypes.Individual, PaymentMethods.CreditCard, OrderStatuses.New);

            // Act
            order.ProcessToWarehouse();

            // Assert
            Xunit.Assert.Equal(OrderStatuses.InWarehouse, order.OrderStatus);
        }
    }
}