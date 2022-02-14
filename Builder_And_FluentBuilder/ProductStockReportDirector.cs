namespace Builder_And_FluentBuilder
{
    public class ProductStockReportDirector
    {
        private readonly IProductStockReportBuilder _productStockReportBuilder;

        public ProductStockReportDirector(IProductStockReportBuilder productStockReportBuilder)
        {
            _productStockReportBuilder = productStockReportBuilder;
        }

        public void BuildStockReport()
        {
            _productStockReportBuilder // Resultat, de går att kedja.
                .BuildHeader()
                .BuildBody()
                .BuildFooter();
            //_productStockReportBuilder.BuildHeader();
            //_productStockReportBuilder.BuildBody();
            //_productStockReportBuilder.BuildFooter();
        }
    }
}
