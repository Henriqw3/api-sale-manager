using System;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{   /// Representa especificações dos itens no momento da venda.
    public class SaleItem : BaseEntity
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public Guid? ProductId { get; set; } // vai ajudar a referenciar um produto no futuro
        public string ProductName { get; set; } // Nome do produto no momento da venda
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Preço do produto no momento da venda
        public decimal TotalAmount { get; private set; }
        public Discount Discount { get; private set; }
        public decimal Total { get; private set; }

        protected SaleItem() { } // Construtor privado ou protegido para o EF Core
        public SaleItem(Guid? productId, string productName, int quantity, decimal unitPrice)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("O nome do produto não pode estar vazio.");

            ItemId = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = new Discount(quantity);
            CalculateTotal();
        }

        public void CalculateTotal()
        {
            Discount = new Discount(Quantity);
            Total = Discount.Apply(Quantity * UnitPrice);
        }
    }
}
