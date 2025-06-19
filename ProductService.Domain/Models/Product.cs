using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Models
{
    public class Product
    {
        public Guid Id { get;  set; }
        public string? Name { get;  set; }
        public string? Description { get;  set; }
        public string? Category { get;  set; }
        public string? ImageUrl { get;  set; }
        public decimal Price { get;  set; }
        public int Stock { get;  set; }

        // Constructor para crear un producto
        public Product(Guid id, string name, string description, string category, string imageUrl, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            ImageUrl = imageUrl;
            Price = price;
            Stock = stock;
        }
    }
}
