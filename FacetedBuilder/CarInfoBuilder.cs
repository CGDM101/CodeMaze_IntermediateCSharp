namespace FacetedBuilder
{
    // one builder:
    public class CarInfoBuilder: CarBuilderFacade // inherits from the facade class.
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }

        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }

        public CarInfoBuilder WithColour(string colour)
        {
            Car.Colour = colour;
            return this;
        }

        public CarInfoBuilder WithNumberOfDoors(int number)
        {
            Car.NumberOfDoors = number;
            return this;
        }
    }
}
