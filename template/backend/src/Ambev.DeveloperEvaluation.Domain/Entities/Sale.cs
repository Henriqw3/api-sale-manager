using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// Representa uma venda.
    public class Sale : BaseEntity
    {
        public Guid SaleId { get; set; } = Guid.NewGuid();
        // External Identities
        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal? TotalAmount { get; private set; }
        public Filial Filial { get; private set; }
        public SaleStatus Status { get; set; } = SaleStatus.Pending;
        public List<SaleItem> Items { get; set; } = [];

        protected Sale() { } // Construtor privado ou protegido para o EF Core
        public Sale(Guid customerId, string customerName, string saleNumber, Filial filial, List<SaleItem> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("A venda deve conter pelo menos um item.");

            SaleId = Guid.NewGuid();
            CustomerId = customerId;
            CustomerName = customerName;
            SaleNumber = saleNumber;
            SaleDate = DateTime.UtcNow;
            Filial = filial;
            Items = items;
            CalculateTotal();
        }

        public void CalculateTotal()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                item.CalculateTotal();
                TotalAmount += item.Total;
            }
        }

        public void CompleteSale()
        {
            if (Status == SaleStatus.Pending)
            {
                Status = SaleStatus.Completed;
            }
        }

        public void CancelSale()
        {
            if (Status == SaleStatus.Pending)
            {
                Status = SaleStatus.Canceled;
            }
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
