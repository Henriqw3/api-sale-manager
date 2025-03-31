using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public record CreateSaleResult
    {
        public Guid SaleId { get; init; }
        public string SaleNumber { get; init; }
        public DateTime SaleDate { get; init; }
        public Guid CustomerId { get; init; }
        public string CustomerName { get; init; }
        public decimal TotalAmount { get; init; }
        public string Status { get; init; }
        public List<SaleItemResult> Items { get; init; }

        public record SaleItemResult
        {
            public Guid ItemId { get; init; }
            public Guid? ProductId { get; init; }
            public string ProductName { get; init; }
            public int Quantity { get; init; }
            public decimal UnitPrice { get; init; }
            public decimal Total { get; init; }
        }
    }
}