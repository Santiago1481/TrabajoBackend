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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidosDTO>>> GetPedidos()
        {
            var pedidos = await _pedidosService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosDTO>> GetPedido(int id)
        {
            var pedido = await _pedidosService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosDTO>> PostPedido(PedidosDTO pedidoDto)
        {
            var createdPedido = await _pedidosService.CreatePedidoAsync(pedidoDto);
            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.Id }, createdPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidosDTO pedidoDto)
        {
            if (id != pedidoDto.Id)
            {
                return BadRequest();
            }

            await _pedidosService.UpdatePedidoAsync(pedidoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            await _pedidosService.DeletePedidoAsync(id);
            return NoContent();
        }
    }
}