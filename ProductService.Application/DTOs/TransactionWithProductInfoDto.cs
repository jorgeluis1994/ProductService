using ProductService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.DTOs
{
    public class TransactionWithProductInfoDto
    {
        public Guid TransactionId { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Detail { get; set; }

        public string ProductName { get; set; }
        public int ProductStock { get; set; }
    }
}
