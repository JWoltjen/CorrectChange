using System;
using System.Diagnostics.Metrics;

namespace ChangeCalculator
{
    class Program
    {
        // Create a console app that takes in an amount owed and an amount paid

        static void Main(string[] args)
        {
            Console.Write("Enter the total amount due: $");
            decimal totalDue;
            while (!decimal.TryParse(Console.ReadLine(), out totalDue) || totalDue < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }

            Console.WriteLine("Enter the amount paid: $");
            decimal amountPaid;
            while (!decimal.TryParse(Console.ReadLine(), out amountPaid) || amountPaid < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }

            decimal maxDenomination = 100M;
            Dictionary<decimal, int> change = CalculateChange(totalDue, amountPaid, maxDenomination);
            if (totalDue > amountPaid)
            {
                Console.WriteLine("Insufficient funds for transaction.");
            }
            else if (change.Count == 0)
            {
                Console.WriteLine("Exact change given.");
            }
            else
            {
                Console.WriteLine("Change Breakdown:");

                foreach (KeyValuePair<decimal, int> entry in change)
                {
                    Console.WriteLine($"${entry.Key}: {entry.Value}");
                }
            }
        }

        public static Dictionary<decimal, int>? CalculateChange(decimal totalDue, decimal amountPaid, decimal maxDenomination)
        {
            decimal change = amountPaid - totalDue;
            if (change < 0 || change == 0)
            {
                return null;
            }

            decimal[] denominations = { 100, 50, 20, 10, 5, 1, 0.25M, 0.10M, 0.05M, 0.01M };
            Dictionary<decimal, int> changeBreakdown = new Dictionary<decimal, int>();

            foreach(decimal denomination in denominations)
            {
                // the customer doesn't necessarily always use 100 or 50 dollar bills to pay for every transaction, so in these cases we skip those possible denominations when calculating change.
                if(denomination > maxDenomination)
                {
                    continue;
                }

                // casting the division as an int prevents the method from returning anything other than whole numbers, which is what we want when counting change, as we can't give 3.25 quarters back to the customer
                int count = (int)(change / denomination);

                // we calculate the remainder of dividing "change" by "denomination" and assigns the result back as the remaining change.
                change %= denomination;

                if (count > 0)
                {
                    changeBreakdown[denomination] = count;
                }
            }
            return changeBreakdown;
        }
    }
}