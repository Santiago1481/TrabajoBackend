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
    public class DetallePedidosController : ControllerBase
    {
        private readonly IDetallePedidosService _detallePedidosService;

        public DetallePedidosController(IDetallePedidosService detallePedidosService)
        {
            _detallePedidosService = detallePedidosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedidoDTO>>> GetDetallePedidos()
        {
            var detallePedidos = await _detallePedidosService.GetAllDetallePedidosAsync();
            return Ok(detallePedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedidoDTO>> GetDetallePedido(int id)
        {
            var detallePedido = await _detallePedidosService.GetDetallePedidoByIdAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            return Ok(detallePedido);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedidoDTO>> PostDetallePedido(DetallePedidoDTO detallePedidoDto)
        {
            var createdDetallePedido = await _detallePedidosService.CreateDetallePedidoAsync(detallePedidoDto);
            return CreatedAtAction(nameof(GetDetallePedido), new { id = createdDetallePedido.Id }, createdDetallePedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedidoDTO detallePedidoDto)
        {
            if (id != detallePedidoDto.Id)
            {
                return BadRequest();
            }

            await _detallePedidosService.UpdateDetallePedidoAsync(detallePedidoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            await _detallePedidosService.DeleteDetallePedidoAsync(id);
            return NoContent();
        }
    }
}