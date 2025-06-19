using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Services;
using ProductService.Application;
using ProductService.Domain.Models;

namespace ProductService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productServices)
        {
            _productService = productServices;
        }

        // Create
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

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // Get all
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // Update
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] CreateProductDto dto)
        //{
        //    var existingProduct = await _productService.GetByIdAsync(id);
        //    if (existingProduct == null)
        //        return NotFound();

        //    existingProduct.Update(dto.Name, dto.Description, dto.Category, dto.ImageUrl, dto.Price, dto.Stock);
        //    await _productService.UpdateAsync(existingProduct);

        //    return NoContent();
        //}

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }

}
