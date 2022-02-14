namespace FacetedBuilder
{
    // A facade:
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            Car = new Car(); // instansierar bilen
        }

        public Car Build() => Car; // bygger den.

        // expose the two builders inside the facade class:
        public CarInfoBuilder Info => new CarInfoBuilder(Car);
        public CarAddressBuilder Built => new CarAddressBuilder(Car);
    }
}
