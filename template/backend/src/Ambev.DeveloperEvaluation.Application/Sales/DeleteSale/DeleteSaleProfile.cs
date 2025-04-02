using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Profile for mapping between DeleteSaleCommand and Sale entity
    /// </summary>
    public class DeleteSaleProfile : Profile
    {
        public DeleteSaleProfile()
        {
            CreateMap<DeleteSaleCommand, Sale>();
            CreateMap<Sale, DeleteSaleResult>();
        }
    }
}
