using System;
using System.Diagnostics.Metrics;

namespace ChangeCalculator
{
    class Program
    {
        // Create a console app that takes in an amount owed and an amount paid

        static void Main(string[] args)
        {
            
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