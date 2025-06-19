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
        [HttpPost("save")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo de la solicitud.");
            }

            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Mapear los campos del DTO al producto existente
            existingProduct.Name = dto.Name;
            existingProduct.Description = dto.Description;
            existingProduct.Category = dto.Category;
            existingProduct.ImageUrl = dto.ImageUrl;
            existingProduct.Price = dto.Price;
            existingProduct.Stock = dto.Stock;

            // Guardar cambios
            await _productService.UpdateAsync(existingProduct);

            // Retornar el producto actualizado
            return Ok(existingProduct);
        }



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
