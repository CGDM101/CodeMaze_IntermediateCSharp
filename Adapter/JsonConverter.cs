using Newtonsoft.Json; // For Json serialisation
using System;
using System.Collections.Generic;

namespace Adapter
{ // Structural. Allows incompatible interfaces to work together. When we want to work with the existing class but its interface is not compatible with the rest of our code. The adapter pattern is a middle-layer which serves as a translator between our code and some third party class with a different interface. Common pattern when having to adapt some existing classes to a new interface.
    public class JsonConverter
    {
        private IEnumerable<Manufacturer> _manufacturers;

        public JsonConverter(IEnumerable<Manufacturer> manufacturers)
        {
            _manufacturers = manufacturers;
        }

        public void ConvertToJson()
        {
            var jsonManufacturers = JsonConvert.SerializeObject(_manufacturers, Formatting.Indented);
            Console.WriteLine("\nPrinting JSON list\n");
            Console.WriteLine(jsonManufacturers);
        }
    }
}
