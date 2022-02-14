using System;
using System.Collections.Generic;
using System.Linq; // Select

namespace Builder_And_FluentBuilder
{
    public class ProductStockReportBuilder : IProductStockReportBuilder
    {
        private ProductStockReport _productStockReport;
        private IEnumerable<Product> _products;

        public ProductStockReportBuilder(IEnumerable<Product> products)
        {
            _products = products;
            _productStockReport = new ProductStockReport();
        }

        public IProductStockReportBuilder BuildHeader() // void
        {
            _productStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {DateTime.Now}\n";
            return this; //
        }

        public IProductStockReportBuilder BuildBody() // void
        {
            _productStockReport.BodyPart = string.Join(Environment.NewLine, _products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
            return this; //
        }

        public IProductStockReportBuilder BuildFooter() // void
        {
            _productStockReport.FooterPart = "\nReport provided by the IT_PRODUCTS company.";
            return this; //
        }

        public ProductStockReport GetReport()
        {
            var productStockReport = _productStockReport;
            Clear();
            return productStockReport;
        }

        private void Clear() => _productStockReport = new ProductStockReport();
    }
}
