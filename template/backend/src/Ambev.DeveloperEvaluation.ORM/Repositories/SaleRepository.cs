using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> GetByIdSale(Guid id)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.SaleId == id);
        }

        public async Task<List<Sale>> GetAllSales()
        {
            return await _context.Sales
                .Include(s => s.Items)
                .ToListAsync();
        }

        public async Task<Sale> AddSale(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> UpdateSale(Sale sale, Guid id)
        {   
            Sale saleByID = await GetByIdSale(id);

            sale.SaleId = saleByID.SaleId;
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> UpdateItems(Sale sale, Guid id)
        {
            Sale saleByID = await GetByIdSale(id);

            if (saleByID == null)
            {
                throw new KeyNotFoundException("Sale not found.");
            }

            foreach (var item in sale.Items)
            {
                var existingItem = saleByID.Items.FirstOrDefault(i => i.ItemId == item.ItemId);
                if (existingItem != null)
                {
                    existingItem.ProductId = item.ProductId;
                    existingItem.ProductName = item.ProductName;
                    existingItem.Quantity = item.Quantity;
                    existingItem.UnitPrice = item.UnitPrice;
                }
                else
                {
                    saleByID.Items.Add(item);
                }
            }

            _context.Sales.Update(saleByID);
            await _context.SaveChangesAsync();

            return saleByID;
        }

        public async Task<bool> DeleteSale(Guid id)
        {
            Sale saleByID = await GetByIdSale(id);

            _context.Sales.Remove(saleByID);
            await _context.SaveChangesAsync();

            return true;
        }   
    }
}
