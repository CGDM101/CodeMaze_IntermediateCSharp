using System;

namespace FactoryMethod
{ // Creational.

    public interface IAirConditioner
    {
        void Operate();
    }

    public class CoolingManager : IAirConditioner
    {
        private readonly double _temperature;

        public CoolingManager(double temperature)
        {
            _temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Cooling the room to the required temperature of {_temperature} degrees");
        }
    }

    public class WarmingManager : IAirConditioner
    {
        private readonly double _temperature;

        public WarmingManager(double temperature)
        {
            _temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Warming the room to the required temperature of {_temperature} degrees");
        }
    }

    // A factory creator for the cooling / warming managager classes:
    // Provides an interface for object creation in derived classes.
    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }

    public class CoolingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new CoolingManager(temperature); // Våra två factory-metoder Create
    }

    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new WarmingManager(temperature);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
