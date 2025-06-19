using ProductService.Application.DTOs;
using ProductService.Domain.Enums;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Services
{
    public interface ITransactionService
    {
        Task AddAsync(Transaction transaction);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Transaction transaction);
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<IEnumerable<TransactionWithProductInfoDto>> 
            GetTransactionsWithProductInfoAsync(
            Guid productId, 
            DateTime? startDate = null, 
            DateTime? endDate = null,
            TransactionType? transactionType = null);
    }
}
