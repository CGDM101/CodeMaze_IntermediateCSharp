namespace Adapter
{ // Structural. Allows incompatible interfaces to work together. When we want to work with the existing class but its interface is not compatible with the rest of our code. The adapter pattern is a middle-layer which serves as a translator between our code and some third party class with a different interface. Common pattern when having to adapt some existing classes to a new interface.
    public class Manufacturer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Year { get; set; }
    }
}
