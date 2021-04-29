using System;

namespace Enumerations
{
    class Program
    {
        public enum DaysInWeek : short // Saving memory
        {
            // More readable than 1 - 7
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday=9,
            Sunday // Will be 10
        }
        static void Main(string[] args)
        {
            DaysInWeek monday = DaysInWeek.Monday;

            Console.WriteLine(monday); // Prints Monday
            Console.WriteLine((int)monday); // Cast, prints 0
        }
    }
}
