namespace FactoryMethod
{ // Creational.
    public class CoolingFactory : AirConditionerFactory
        {
            public override IAirConditioner Create(double temperature) => new CoolingManager(temperature); // Våra två factory-metoder Create
        }
    }
