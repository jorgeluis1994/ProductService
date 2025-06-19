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
        public Guid Id { get;  set; }
        public DateTime Date { get;  set; }
        public TransactionType Type { get;  set; }  // Compra o Venta
        public Guid ProductId { get;  set; }
        public int Quantity { get;  set; }
        public decimal UnitPrice { get;  set; }
        public decimal TotalPrice { get;  set; }
        public string? Detail { get;  set; }
    }
}
