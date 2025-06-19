using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Category { get; private set; }
        public string? ImageUrl { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

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
