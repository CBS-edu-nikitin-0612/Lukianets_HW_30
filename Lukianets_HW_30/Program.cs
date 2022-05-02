using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MonthCollection monthCollection = new MonthCollection();

            foreach (Month month in monthCollection)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine("\nHave 30 days: ");
            Month[] have30days = monthCollection.GetMonthsByNumberOfDays(30);
            foreach (Month month in have30days)
                Console.WriteLine(month);

            Console.WriteLine("\nHave 28 days: ");
            Month[] have28days = monthCollection.GetMonthsByNumberOfDays(28);
            foreach (Month month in have28days)
                Console.WriteLine(month);

            Console.WriteLine("\nSelect month by number: monthCollection[4] results in:");
            Console.WriteLine(monthCollection[4]);

        }
    }
}
