namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale.
/// </summary>
public class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<SaleItemRequest> Items { get; set; } = new();
}

/// <summary>
/// Represents an item in a sale.
/// </summary>
public class SaleItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
