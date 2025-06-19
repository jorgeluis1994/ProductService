using ProductService.Domain.Enums;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetByProductIdAsync(Guid productId);
        Task<IEnumerable<Transaction>> GetByFilterAsync(Guid productId, DateTime? fromDate, DateTime? toDate, TransactionType? type);
        Task AddAsync(Transaction transaction);
    }
}
