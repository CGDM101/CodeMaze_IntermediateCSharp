using System;
using System.Linq; // Sum()

namespace LS_P
{
    public class SumCalculator:Calculator
    {
        protected readonly int[] numbers;

        public SumCalculator(int[] numbers)
            :base(numbers)
        {
        }

        public override int Calculate() => _numbers.Sum();
    }

    public class EvenNumbersSumCalculator : Calculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            :base(numbers)
        {
        }

        public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum(); 
    }

    public abstract class Calculator
    {
        protected readonly int[] _numbers;

        public Calculator(int[] numbers)
        {
            _numbers = numbers;
        }

        public abstract int Calculate(); // ingen kropp.
    }

    class Program
    {
        // Child class objects should be able to replace parent class objects without compromising application integrity. Create such derived class objects which can replace objects of the base class without modifying its behaviour. Else, the application might end up being broken.
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            // PROBLEM:
            //SumCalculator evenSum2 = new EvenNumbersSumCalculator(numbers);
            //Console.WriteLine($"The sum of all the even numbers: {evenSum2.Calculate()}"); // 40 - fel!

            // If a child class inherits from a parent class, the child IS A parent class. Calculate() from the higher order base is executed. This child is not behaving as a substitute for the parent class!

            // After adding virtual in parent and overrides it in child, the child's Calculate() will be used instead (so the result of evenSum2 will correctly be 18).
            // Still, the problem is that the derived class cannot replace the base class - LSP is not implemented. Solution - an abstract class Calculator.
            Calculator sumLsp = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sumLsp.Calculate()}");

            Console.WriteLine();

            Calculator evenSumLsp = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSumLsp.Calculate()} ");
        }
    }
}
