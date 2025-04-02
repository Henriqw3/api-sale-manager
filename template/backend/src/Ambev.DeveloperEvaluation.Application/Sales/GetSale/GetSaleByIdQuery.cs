using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleByIdQuery : IRequest<GetSaleByIdResult>
    {
        public Guid SaleId { get; set; }
    }
}
