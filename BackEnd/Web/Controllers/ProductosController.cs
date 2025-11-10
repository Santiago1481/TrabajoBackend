using Business.Interfaces;
using Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductosDTO>>> GetProductos()
        {
            var productos = await _productosService.GetAllProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductosDTO>> GetProducto(int id)
        {
            var producto = await _productosService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductosDTO>> PostProducto(ProductosDTO productoDto)
        {
            var createdProducto = await _productosService.CreateProductoAsync(productoDto);
            return CreatedAtAction(nameof(GetProducto), new { id = createdProducto.Id }, createdProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductosDTO productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest();
            }

            await _productosService.UpdateProductoAsync(productoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productosService.DeleteProductoAsync(id);
            return NoContent();
        }
    }
}