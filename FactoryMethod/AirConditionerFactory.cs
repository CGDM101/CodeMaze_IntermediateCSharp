namespace FactoryMethod
{ // Creational.
  // A factory creator for the cooling / warming managager classes:
  // Provides an interface for object creation in derived classes.
    public abstract class AirConditionerFactory
        {
            public abstract IAirConditioner Create(double temperature);
        }
    }
