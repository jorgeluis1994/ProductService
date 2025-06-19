using ProductService.Application.DTOs;
using ProductService.Domain.Models;
using ProductService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductService.Domain.Enums;

namespace ProductService.Application.Services
{

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;

        public TransactionService(ITransactionRepository transactionRepository, IProductRepository productRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _transactionRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _transactionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }

        public async Task<IEnumerable<TransactionWithProductInfoDto>> GetTransactionsWithProductInfoAsync(
            Guid productId, DateTime? startDate = null, DateTime? endDate = null, TransactionType? transactionType = null)
        {
            var transactions = await _transactionRepository.GetTransactionsByProductAsync(productId, startDate, endDate, transactionType);

            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null) return new List<TransactionWithProductInfoDto>();

            var result = transactions.Select(t => new TransactionWithProductInfoDto
            {
                TransactionId = t.Id,
                Date = t.Date,
                TransactionType = t.Type,
                Quantity = t.Quantity,
                UnitPrice = t.UnitPrice,
                TotalPrice = t.TotalPrice,
                Detail = t.Detail,
                ProductName = product.Name,
                ProductStock = product.Stock
            });

            return result;
        }
    }
}
