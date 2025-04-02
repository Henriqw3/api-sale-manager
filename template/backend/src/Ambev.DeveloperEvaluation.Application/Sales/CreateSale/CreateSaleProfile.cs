using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            // Command -> Entidade (opcional, se necessário)
            CreateMap<CreateSaleCommand, Sale>()
                .ForMember(dest => dest.Items, opt => opt.Ignore()) // Items são mapeados manualmente
                .ForMember(dest => dest.SaleNumber, opt => opt.Ignore()); // Gerado pelo handler

            // Command.Item -> Entidade.Item
            CreateMap<CreateSaleCommand.CreateSaleItemCommand, SaleItem>();

            // Entidade -> Result (já existente)
            CreateMap<Sale, CreateSaleResult>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<SaleItem, CreateSaleResult.SaleItemResult>();
        }
    }
}
