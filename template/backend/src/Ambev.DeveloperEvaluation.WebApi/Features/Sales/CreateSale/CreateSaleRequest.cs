namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale.
    /// </summary>
    public class CreateSaleRequest
    {
        public Guid? CustomerId { get; init; }
        public string CustomerName { get; init; } = string.Empty;
        public string SaleNumber { get; init; } = string.Empty;
        public DateTime SaleDate { get; init; }
        public List<SaleItemRequest> Items { get; init; } = [];
    }
    /// <summary>
    /// Represents an item in a sale.
    /// </summary>
    public class SaleItemRequest
    {
        public Guid? ProductId { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
    }
}