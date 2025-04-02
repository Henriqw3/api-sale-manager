using FluentValidation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validador para CreateSaleRequest, definindo regras de validação para a criação de uma venda.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Inicializa uma nova instância do CreateSaleRequestValidator com regras de validação definidas.
    /// </summary>
    public CreateSaleRequestValidator()
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
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("SaleDate não pode ser no futuro.");

        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("A venda deve conter pelo menos um item.")
            .Must(items => items.All(item => item.Quantity > 0))
            .WithMessage("Todos os itens devem ter quantidade maior que zero.");

        RuleForEach(sale => sale.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Preço unitário deve ser maior ou igual a zero.");
        });
    }
}
