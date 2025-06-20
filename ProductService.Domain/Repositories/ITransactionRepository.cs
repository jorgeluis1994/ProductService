﻿using ProductService.Domain.Enums;
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
        Task AddAsync(Transaction transaction);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Transaction transaction);
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetAllAsync();

        // Método para filtrar por producto, fechas y tipo
        Task<IEnumerable<Transaction>> GetTransactionsByProductAsync(
            Guid productId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            TransactionType? transactionType = null);
    }
}
