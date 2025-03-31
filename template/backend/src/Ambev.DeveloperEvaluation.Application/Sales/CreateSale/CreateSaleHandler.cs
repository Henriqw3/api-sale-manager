using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
//using Ambev.DeveloperEvaluation.Application.Common;
using OneOf.Types;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Result<CreateSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<Result<CreateSaleResult>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        // Mapeia o Command para a entidade (complementando campos não automáticos)
        var sale = _mapper.Map<Sale>(request);
        //sale.SaleNumber = GenerateSaleNumber();
        sale.Items = request.Items.Select(_mapper.Map<SaleItem>).ToList();
        sale.CalculateTotal();

        // Validação e persistência (igual ao anterior)
        var validationResult = sale.Validate();
        if (!validationResult.IsValid)
            //return Result<CreateSaleResult>.Failure(validationResult.Errors);
            throw new ValidationException("A venda deve conter itens");

        var createdSale = await _saleRepository.AddSale(sale);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return new Result<CreateSaleResult>(result);
    }
}

