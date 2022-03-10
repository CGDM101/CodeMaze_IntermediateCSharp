using System;

namespace IS_P
{
    public interface ICar
    {
        void Drive();
    }

    public interface IAirPlane
    {
        void Fly();
    }

    public class MultiFunctionalCar : ICar, IAirPlane
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

    public interface IMultifuctionalVehicle : ICar, IAirPlane { } // a higherlevel interface

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving a car.");
        }
    }

    public class AirPlane : IAirPlane
    {
        public void Fly()
        {
            Console.WriteLine("Flying a plane.");
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
