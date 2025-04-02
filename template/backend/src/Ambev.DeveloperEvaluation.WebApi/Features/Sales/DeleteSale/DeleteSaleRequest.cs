namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
/// <summary>
/// Request model for deleting a sale
/// </summary>
{
    public class DeleteSaleRequest
    {
        public Guid SaleId { get; set; }
    }
}