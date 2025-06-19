using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Services;
using ProductService.Application.UseCases;
using ProductService.Domain.Models;

namespace ProductService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductServices _productService;
        public ProductsController(IProductServices productServices)
        {
            _productService = productServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = new Product(
                Guid.NewGuid(),
                dto.Name,
                dto.Description,
                dto.Category,
                dto.ImageUrl,
                dto.Price,
                dto.Stock);

            await _productService.AddAsync(product);

            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}
