using System;

namespace Inheritance
{
    public class Writer
    {
        public void Write()
        {
            Console.WriteLine("Writing to a file");
        }
    }

    public class XMLWriter : Writer
    {
        public void FormatXMLFile()
        {
            Console.WriteLine("Format XML file");
        } // Plus the Write() from the base class!
    }

    public class JSONWriter : Writer
    {
        public void FormatJSONFile()
        {
            Console.WriteLine("Formatting JSON file");
        } // Plus the Write() from the base class!
    }

    class Program
    {
        static void Main(string[] args)
        {
            XMLWriter xmlWriter = new XMLWriter();
            xmlWriter.FormatXMLFile();
            xmlWriter.Write(); // Method comes from base class

            // EXAMPLE WITH CALLING CONSTRUCTORS FROM BASE CLASS:
            XMLWriter2 xMLWriter = new XMLWriter2("xmlFileName"); // Pass a string value to the derived class' constructor
            xmlWriter.FormatXMLFile();
            xmlWriter.Write();
            Console.WriteLine(xMLWriter.FileName);

            JSONWriter2 jsonWriter = new JSONWriter2("jsonFileName");
            jsonWriter.FormatJSONFile();
            jsonWriter.Write();
            Console.WriteLine(jsonWriter.FileName);

            // ACCESSING CLASSES:
            XMLWriter2 xml = new XMLWriter2("file.xml");
            Writer2 writer = xml;
            writer.Write(); // Ok, Write() is part of the Writer class
            writer.FormatXML(); // Error, FormatXML() not part Writer class

            // More on access
            Writer2 w = new Writer2("any name");
            XMLWriter xmlWri = w; // Error, cannot convert base to derived
            // Solution, by using the as keyword: (fattar inte)
            XMLWriter2 xmll = new XMLWriter2("any name");
            Writer2 writerr = xmll; // writerr points to xmll
            // SOLVE THE PROBLEM WITH AS KEYWORD:
            XMLWriter2 newWriter = writerr as XMLWriter2; // Ok, bc writerr was xmll
            newWriter.FormatXMLFile();
        }
    }

    // CALLING CONSTUCTORS FROM BASE CLASS:
    public class Writer2
    {
        public string FileName { get; set; }
        public Writer2(string fileName) // Constrcutor in base class
        {
            FileName = fileName;
        }
        public void Write()
        {
            Console.WriteLine("Writing to a file");
        }

        // HIDING:
        public void SetName()
        {
            Console.WriteLine("Setting name in the base Writer class");
        }
        // OVERRIDING:
        public virtual void CalculateFileSize()
        {
            Console.WriteLine("Calculating file size in a Writer class");
        }
    }
    public class XMLWriter2 : Writer2
    {
        public XMLWriter2(string fileName)
            :base(fileName) // Accessing the constructor of the base class. The FileName property are shared between derived classes.
        {
        }
        public void FormatXMLFile()
        {
            Console.WriteLine("Format XML file");
        }

        // HIDING:
        public new void SetName() // "XMLWriter2.SetName() hides inherited member Writer2.SetName(). Use new if hiding was intended."
        {
            Console.WriteLine("Setting name in the XMLWriter class");
        }
        // OVERRIDING:
        public override void CalculateFileSize()
        {
            base.CalculateFileSize();
            Console.WriteLine("Calculate file size in the XMLWriter class");
        }
    }

    public class JSONWriter2 : Writer2
    {
        public JSONWriter2(string fileName)
            :base(fileName) // Passing the string value from main to the constructor of the base class. In the constructor for the base class, the value for the FileName property is set up.
        {
        }
        public void FormatJSONFile()
        {
            Console.WriteLine("Formatting JSON file");
        }
    }
}
