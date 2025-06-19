using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Services;
using ProductService.Domain.Enums;
using ProductService.Domain.Models;

namespace ProductService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAll()
        {
            var transactions = await _transactionService.GetAllAsync();
            return Ok(transactions);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Date = dto.Date,
                Type = dto.Type,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                TotalPrice = dto.Quantity * dto.UnitPrice,
                Detail = dto.Detail
            };

            await _transactionService.AddAsync(transaction);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetTransactionsByProduct(
            Guid productId,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] TransactionType? transactionType)
        {
            var transactions = await _transactionService.GetTransactionsWithProductInfoAsync(productId, startDate, endDate, transactionType);
            return Ok(transactions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var existingProduct = await _transactionService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            await _transactionService.DeleteAsync(id);
            return NoContent();
        }
    }
         
        
}
