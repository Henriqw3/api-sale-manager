namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public record UpdateSaleResponse
    {
        public Guid SaleId { get; init; }
        public string SaleNumber { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public decimal TotalAmount { get; init; }
        public List<SaleItemResponse> Items { get; init; } = [];
    }
    public record SaleItemResponse
    {
        public Guid ItemId { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
        public decimal TotalAmount { get; init; }
    }
}