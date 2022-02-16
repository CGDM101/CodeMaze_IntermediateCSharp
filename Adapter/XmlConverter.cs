using System;
using System.Linq;
using System.Xml.Linq; // XDocument

namespace Adapter
{ // Structural. Allows incompatible interfaces to work together. When we want to work with the existing class but its interface is not compatible with the rest of our code. The adapter pattern is a middle-layer which serves as a translator between our code and some third party class with a different interface. Common pattern when having to adapt some existing classes to a new interface.
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
}
