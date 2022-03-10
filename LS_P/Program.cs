using System;
using System.Linq; // Sum()

namespace LS_P
{
    public class SumCalculator
    {
        protected readonly int[] _numbers;

        public SumCalculator(int[] numbers)
        {
            _numbers = numbers;
        }

        public int Calculate() => _numbers.Sum();
    }

    public class EvenNumbersSumCalculator : SumCalculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            :base(numbers)
        {
        }

        public new int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
    }

    class Program
    {
        // Child class objects should be able to replace parent class objects without compromising application integrity. Create such derived class objects which can replace objects of the base class without modifying its behaviour. Else, the application might end up being broken.
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            SumCalculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}"); // 40

            Console.WriteLine();

            EvenNumbersSumCalculator evenSum = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}"); // 18

            // PROBLEM:
            SumCalculator evenSum2 = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum2.Calculate()}"); // 40 - fel!

            // If a child class inherits from a parent class, the child IS A parent class. Calculate() from the higher order base is executed. This child is not behaving as a substitute for the parent class!
        }
    }
}
