using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Helpers
{
    public static class ValueParser
    {

        public static int ParseInt(string message)
        {
            int result;
            Console.Write(message);
            string input = Console.ReadLine();
            bool flag = int.TryParse(input, out result) && result > 0;
            while (!flag)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number greater than 0:");
                input = Console.ReadLine();
                flag = int.TryParse(input, out result) && result > 0;
            }
            return result;
        }

        public static decimal ParseDecimal(string message)
        {
            decimal result;
            Console.Write(message);
            string input = Console.ReadLine();
            bool flag = decimal.TryParse(input, out result) && result > 0;
            while (!flag)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number greater than 0:");
                input = Console.ReadLine();
                flag = decimal.TryParse(input, out result) && result > 0;
            }
            return decimal.Round(result,2, MidpointRounding.AwayFromZero);
        }
    }
}
