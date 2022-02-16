namespace FactoryMethod
{ // Creational.

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
