using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSavers
{
    class DemoRefactor
    {
        public void ProcessData()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = 0;
            int product = 1;
            int max = int.MinValue;
            int min = int.MaxValue;

            foreach (int num in numbers)
            {
                // Calculate the sum
                sum += num;

                // Calculate the product
                product *= num;

                // Find the maximum
                if (num > max)
                {
                    max = num;
                }

                // Find the minimum
                if (num < min)
                {
                    min = num;
                }
            }

            // Print the results
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Product: " + product);
            Console.WriteLine("Maximum: " + max);
            Console.WriteLine("Minimum: " + min);
        }

    }

}
