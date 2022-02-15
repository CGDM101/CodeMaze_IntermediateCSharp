using System;
using System.Collections.Generic;

namespace FactoryMethod
{ // Creational.

    public enum Actions
    {
        Cooling,
        Warming
    }

    public class AirConditioner
    {
        private readonly Dictionary<Actions, AirConditionerFactory> _factories;

        private AirConditioner()
        {
            //_factories = new Dictionary<Actions, AirConditionerFactory>
            //{
            //    { Actions.Cooling, new CoolingFactory() },
            //    { Actions.Warming, new WarmingFactory() }
            //};
            _factories = new Dictionary<Actions, AirConditionerFactory>();

            foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
                _factories.Add(action, factory);
            }
        }

        // To be able to chain methods in main:
        public static AirConditioner InitialiseFactories() => new AirConditioner();

        public IAirConditioner ExecuteCreatiion(Actions action, double temperature) => _factories[action].Create(temperature);
    }
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
            //var factory = new AirConditioner().ExecuteCreatiion(Actions.Cooling, 22.5);
            //factory.Operate();
            // chaining:
            AirConditioner
            .InitialiseFactories()
            .ExecuteCreatiion(Actions.Cooling, 22.5)
            .Operate();
            }
        }
    }
