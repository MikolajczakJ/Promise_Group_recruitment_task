using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Helpers
{
    public static class Seeder
    {
        public static void Seed()
        {
            using (var db = new WarehouseDbContext())
            {
                if (db.Orders.Count() == 0)
                {
                    db.Orders.AddRange(new List<Order>
                    {
                        new Order(3000,"Order 1","Address 1",ClientTypes.Individual,PaymentMethods.CreditCard,OrderStatuses.New),
                        new Order(3000,"Order 2","Address 2",ClientTypes.Company,PaymentMethods.Cash,OrderStatuses.New),
                        new Order(300,"Order 3","Address 3",ClientTypes.Individual,PaymentMethods.CreditCard,OrderStatuses.New),
                        new Order(250,"Order 4","Address 4",ClientTypes.Individual,PaymentMethods.CreditCard,OrderStatuses.New),
                        new Order(10,"Order 5","Address 5",ClientTypes.Company,PaymentMethods.Cash,OrderStatuses.Closed),
                        new Order(400,"Order 6","Address 6",ClientTypes.Individual,PaymentMethods.CreditCard,OrderStatuses.New),
                        new Order(100,"Order 7","Address 7",ClientTypes.Company,PaymentMethods.CreditCard,OrderStatuses.New),
                        new Order(321,"Order 8","Address 8",ClientTypes.Company,PaymentMethods.Cash,OrderStatuses.Closed),
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
