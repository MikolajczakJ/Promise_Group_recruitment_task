using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Helpers;

namespace WarehouseManagementSystem
{
    public static class MainMenu
    {
        public static void MainMenuScreen()
        {
            OrderService _orderService = new OrderService();
            int option;

            Seeder.Seed();
            do
            {
                option = MenuHelper.MultipleChoice("Choose an option:", "Create order", "Orders", "Move to warehouse", "Move to delivery", "Exit");
                switch (option)
                {
                    case 0:
                        if (_orderService.AddOrder())
                            Console.WriteLine("Order added successfully");
                        else
                            Console.WriteLine("Something went wrong");
                        break;
                    case 1:
                        _orderService.ListOrders(_orderService.GetOrders());
                        break;
                    case 2:
                        _orderService.UpdateOrderStatus(OrderStatuses.InWarehouse);
                        break;
                    case 3:
                        _orderService.UpdateOrderStatus(OrderStatuses.InDelivery);
                        break;
                }
            } while (option != 4);
        }
    }
}
