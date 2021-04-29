using System;

namespace Interfaces
{
    public interface IWriter
    {
        void WriteFile(); // No access modifier, no body.
    }

    public class FileBase
    {
        public virtual void SetName()
        {
            Console.WriteLine("Setting name in the base Writer class");
        }
    }
    public class XMLWriter : IWriter
    {
        public void WriteFile()
        {
            Console.WriteLine("Writing file in the XMLWriter class");
        }
    }
    public class JsonWriter : FileBase, IWriter
    {
        public void WriteFile()
        {
            Console.WriteLine("Writing file in the JsonWriter class.");
        }
        public override void SetName()
        {
            Console.WriteLine("Setting name in the JsonWriter class");
        }

    }
    public class XmlWriter : FileBase, IWriter // både klass och interface
    {
        public void WriteFile()
        {
            Console.WriteLine("Writing file in the XmlWriter class");
        }
        public override void SetName()
        {
            Console.WriteLine("Setting name in the XmlWriter class");
        }
    }


    public class YetAnotherWriter : FileBase, IWriter
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
