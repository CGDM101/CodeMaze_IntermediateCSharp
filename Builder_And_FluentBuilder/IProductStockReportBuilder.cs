namespace Builder_And_FluentBuilder
{
    public interface IProductStockReportBuilder
    {
        IProductStockReportBuilder BuildHeader(); // void
        IProductStockReportBuilder BuildBody(); // void
        IProductStockReportBuilder BuildFooter(); // void
        ProductStockReport GetReport();
    }
}
