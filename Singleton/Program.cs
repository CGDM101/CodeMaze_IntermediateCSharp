using System;
using System.Collections.Generic;
using System.IO;

namespace Singleton
{ // Creational.

    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }

    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initialising singleton object");

            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        //private static SingletonDataContainer instance = new SingletonDataContainer();
        // Lazy loaded to make it thread safe:
        // Lazy loaded means the instance is going to be created onley when it is acutally needed.
        private static Lazy<SingletonDataContainer> instance = new Lazy<SingletonDataContainer>(() => new SingletonDataContainer());

        //public static SingletonDataContainer Instance => instance;
        public static SingletonDataContainer Instance => instance.Value;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance; // Initialising singleton object

            var dbb = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Washington, D.C."));
            var dbb2 = SingletonDataContainer.Instance;
            Console.WriteLine(dbb2.GetPopulation("London"));
        }
    }
}
