using System;

namespace IS_P
{
    public interface IVehicle
    {
        void Drive();
        void Fly();
    }

    public class MultiFunctionalCar : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Drive a multifunctional car.");
        }

        public void Fly()
        {
            Console.WriteLine("Fly a multifunctional car.");
        }
    }

    class Program
    {
        // No client should be forced to depend upon methods it does not use.
        // We should reduce code objects down to the smallest implemenation, thus creating interfaces with only required declarations. So, an interface that has a lot of different declarations should be split up into smaller interfaces.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
