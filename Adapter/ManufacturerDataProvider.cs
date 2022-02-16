using System.Collections.Generic;

namespace Adapter
{ // Structural. Allows incompatible interfaces to work together. When we want to work with the existing class but its interface is not compatible with the rest of our code. The adapter pattern is a middle-layer which serves as a translator between our code and some third party class with a different interface. Common pattern when having to adapt some existing classes to a new interface.
    public static class ManufacturerDataProvider
    {
        public static List<Manufacturer> GetData() => // static...
           new List<Manufacturer>
           {
                new Manufacturer { City = "Italy", Name = "Alfa Romeo", Year = 2016 },
                new Manufacturer { City = "UK", Name = "Aston Martin", Year = 2018 },
                new Manufacturer { City = "USA", Name = "Dodge", Year = 2017 },
                new Manufacturer { City = "Japan", Name = "Subaru", Year = 2016 },
                new Manufacturer { City = "Germany", Name = "BMW", Year = 2015 }
           };
    }
}
