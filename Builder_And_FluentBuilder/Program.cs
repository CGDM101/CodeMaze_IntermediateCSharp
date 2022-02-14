using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // stringbuilder

namespace Builder_And_FluentBuilder
{
    // A creational design pattern to create an object one step at a time. Creating complex objects. Finally connect all the parts together. Otherwise we can end up with a large constructor to provide all the parametres for our object.

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductStockReport
    {
        public string HeaderPart { get; set; }
        public string BodyPart { get; set; }
        public string FooterPart { get; set; }

        public override string ToString() =>
            new StringBuilder()
            .AppendLine(HeaderPart)
            .AppendLine(BodyPart)
            .AppendLine(FooterPart)
            .ToString();
    }

    public interface IProductStockReportBuilder
    {
        void BuildHeader();
        void BuildBody();
        void BuildFooter();
        ProductStockReport GetReport();
    }

    public class ProductStockReportBuilder : IProductStockReportBuilder
    {
        private ProductStockReport _productStockReport;
        private IEnumerable<Product> _products;

        public ProductStockReportBuilder(IEnumerable<Product> products)
        {
            _products = products;
            _productStockReport = new ProductStockReport();
        }

        public void BuildHeader()
        {
            _productStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {DateTime.Now}\n";
        }

        public void BuildBody()
        {
            _productStockReport.BodyPart = string.Join(Environment.NewLine, _products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
        }

        public void BuildFooter()
        {
            _productStockReport.FooterPart = "\nReport provided by the IT_PRODUCTS company.";
        }

        public ProductStockReport GetReport()
        {
            var productStockReport = _productStockReport;
            Clear();
            return productStockReport;
        }

        private void Clear() => _productStockReport = new ProductStockReport();
    }

    public class ProductStockReportDirector
    {
        private readonly IProductStockReportBuilder _productStockReportBuilder;

        public ProductStockReportDirector(IProductStockReportBuilder productStockReportBuilder)
        {
            _productStockReportBuilder = productStockReportBuilder;
        }

        public void BuildStockReport()
        {
            _productStockReportBuilder.BuildHeader();
            _productStockReportBuilder.BuildBody();
            _productStockReportBuilder.BuildFooter();
        }
    }

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
