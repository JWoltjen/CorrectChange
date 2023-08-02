using System;

namespace ChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount owed:");
            decimal amountOwed = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount paid:");
            decimal amountPaid = decimal.Parse(Console.ReadLine());

            decimal change = amountPaid - amountOwed;

            if (change < 0)
            {
                Console.WriteLine("The amount paid is less than the amount owed. Please pay the full amount.");
            }
            else if (change == 0)
            {
                Console.WriteLine("No change is owed. Thank you!");
            }
            else if (change < 1)
            {
                Console.WriteLine($"Change owed: ${change}");
                CalculateCoins(change);
            }
            else
            {
                Console.WriteLine($"Change owed: ${change}");
            }
        }

        static void CalculateCoins(decimal change)
        {
            int quarters = (int)(change / 0.25m);
            change %= 0.25m;

            int dimes = (int)(change / 0.10m);
            change %= 0.10m;

            int nickels = (int)(change / 0.05m);
            change %= 0.05m;

            int pennies = (int)(change / 0.01m);

            Console.WriteLine("Change breakdown:");
            Console.WriteLine($"Quarters: {quarters}");
            Console.WriteLine($"Dimes: {dimes}");
            Console.WriteLine($"Nickels: {nickels}");
            Console.WriteLine($"Pennies: {pennies}");
        }
    }
}