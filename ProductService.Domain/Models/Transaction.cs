using ProductService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public TransactionType Type { get; private set; }  // Compra o Venta
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string? Detail { get; private set; }
    }
}
