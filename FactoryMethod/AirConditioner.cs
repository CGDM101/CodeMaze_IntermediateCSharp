using System;
using System.Collections.Generic;

namespace FactoryMethod
{ // Creational.
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
    }
