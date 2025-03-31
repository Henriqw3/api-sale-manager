using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdSale(Guid id);
        Task<List<Sale>> GetAllSales();
        Task<Sale> AddSale(Sale sale);
        Task<Sale> UpdateSale(Sale sale, Guid id);
        Task<bool> DeleteSale(Guid id);
    }
}
