using Newtonsoft.Json; // For Json serialisation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq; // XDocument

namespace Adapter
{ // Structural. Allows incompatible interfaces to work together. When we want to work with the existing class but its interface is not compatible with the rest of our code. The adapter pattern is a middle-layer which serves as a translator between our code and some third party class with a different interface. Common pattern when having to adapt some existing classes to a new interface.

    public class Manufacturer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Year { get; set; }
    }

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

    public class XmlConverter
    {
        public XDocument GetXML()
        {
            var xDocument = new XDocument();
            var xElement = new XElement("Manufacturers");
            var xAttributes = ManufacturerDataProvider.GetData()
                .Select(m => new XElement("Manufacturer",
                new XAttribute("City", m.City),
                new XAttribute("Name", m.Name),
                new XAttribute("Year", m.Year)));

            xElement.Add(xAttributes);
            xDocument.Add(xElement);

            Console.WriteLine(xDocument);

            return xDocument;
        }
    }

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

     // Interface to define the behaviour of the adapter class
    public interface IXmlToJson
    {
        void ConvertXmlToJson();
    }

    public class XmlToJsonAdapter : IXmlToJson // adapterklass
    {
        private readonly XmlConverter _xmlConverter;

        public XmlToJsonAdapter(XmlConverter xmlConverter)
        {
            _xmlConverter = xmlConverter;
        }

        public void ConvertXmlToJson()
        {
            var manufacturers = _xmlConverter.GetXML()
                    .Element("Manufacturers")
                    .Elements("Manufacturer")
                    .Select(m => new Manufacturer
                    {
                        City = m.Attribute("City").Value,
                        Name = m.Attribute("Name").Value,
                        Year = Convert.ToInt32(m.Attribute("Year").Value)
                    });

            new JsonConverter(manufacturers)
                .ConvertToJson();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var xmlConverter = new XmlConverter();
            var adapter = new XmlToJsonAdapter(xmlConverter);
            adapter.ConvertXmlToJson();
        }
    }
}
