using System;
using System.Collections.Generic;

namespace Builder_And_FluentBuilder
{
    // A creational design pattern to create an object one step at a time. Creating complex objects. Finally connect all the parts together. Otherwise we can end up with a large constructor to provide all the parametres for our object.

    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product { Name = "Monitor", Price = 200.50 },
                new Product { Name = "Mouse", Price = 20.41 },
                new Product { Name = "Keyboard", Price = 30.15 }
            };

            var builder = new ProductStockReportBuilder(products);
            var director = new ProductStockReportDirector(builder);
            director.BuildStockReport();

            var report = builder.GetReport();
            Console.WriteLine(report);
        }
    }
}
