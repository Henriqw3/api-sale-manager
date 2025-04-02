namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public record UpdateSaleRequest
    {
        public string CustomerName { get; init; } = string.Empty;
        public List<CreateSaleItemRequest> Items { get; init; } = [];
    }
    public record CreateSaleItemRequest
    {
        public Guid? ProductId { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
    }
}