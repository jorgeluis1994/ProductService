using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Enums;
using ProductService.Domain.Models;
using ProductService.Domain.Repositories;
using ProductService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly DataDbContext _dbContext;
        public TransactionRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _dbContext.Transactions.Remove(transaction);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _dbContext.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByProductAsync(Guid productId, DateTime? startDate = null, DateTime? endDate = null, TransactionType? transactionType = null)
        {
            var query = _dbContext.Transactions.AsQueryable();

            query = query.Where(t => t.ProductId == productId);

            if (startDate.HasValue)
                query = query.Where(t => t.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(t => t.Date <= endDate.Value);

            if (transactionType.HasValue)
                query = query.Where(t => t.Type == transactionType.Value);

            return await query.ToListAsync();
        }

        
    }
}
