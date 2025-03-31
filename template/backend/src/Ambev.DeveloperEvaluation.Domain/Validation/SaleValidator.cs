using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.CustomerId)
                .NotEmpty().WithMessage("CustomerId não pode ser vazio.");

            RuleFor(sale => sale.CustomerName)
                .NotEmpty().WithMessage("CustomerName não pode ser vazio.")
                .MaximumLength(100).WithMessage("CustomerName não pode ter mais de 100 caracteres.");

            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("SaleNumber não pode ser vazio.")
                .MaximumLength(50).WithMessage("SaleNumber não pode ter mais de 50 caracteres.");

            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("SaleDate não pode ser vazio.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("SaleDate não pode ser no futuro.");

            RuleFor(sale => sale.TotalAmount)
                .GreaterThanOrEqualTo(0).WithMessage("TotalAmount deve ser maior ou igual a zero.");

            RuleFor(sale => sale.Filial)
                .NotNull().WithMessage("Filial não pode ser nulo.");

            RuleFor(sale => sale.Status)
                .IsInEnum().WithMessage("Status deve ser um valor válido do enum SaleStatus.");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("Items não pode ser vazio.")
                .Must(items => items.All(item => item.Quantity > 0)).WithMessage("Todos os itens devem ter quantidade maior que zero.")
                .Must(items => items.All(item => item.UnitPrice >= 0)).WithMessage("Todos os itens devem ter preço unitário maior ou igual a zero.");
        }
    }
}
