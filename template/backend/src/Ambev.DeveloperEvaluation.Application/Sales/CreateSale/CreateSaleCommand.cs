using MediatR;
using OneOf.Types;
using System;
using System.Collections.Generic;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Representa o comando para criar uma venda, atuando como um DTO (Data Transfer Objects) da camada de aplicação, mas com uma responsabilidade 
    /// adicional: além de transportar dados, ele representa uma intenção de ação (um comando CQRS) ao implementar IRequest<Result<CreateSaleResult>>
    /// </summary>
    public record CreateSaleCommand : IRequest<Result<CreateSaleResult>>
    {
        public Guid? CustomerId { get; init; }
        public string? CustomerName { get; set; }
        public DateTime SaleDate { get; set; }
        public List<CreateSaleItemCommand> Items { get; set; } = [];

        /// <summary>
        /// Representa um item dentro da venda.
        /// </summary>
        public record CreateSaleItemCommand
        {
            public Guid ItemId { get; set; }
            public Guid? ProductId { get; init; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; } // Incluí UnitPrice para cálculo
        }
    }
    
}