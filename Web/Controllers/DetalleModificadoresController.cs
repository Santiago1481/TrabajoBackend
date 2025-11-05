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
    public class DetalleModificadoresController : ControllerBase
    {
        private readonly IDetalleModificadoresService _detalleModificadoresService;

        public DetalleModificadoresController(IDetalleModificadoresService detalleModificadoresService)
        {
            _detalleModificadoresService = detalleModificadoresService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleModificadorDTO>>> GetDetalleModificadores()
        {
            var detalleModificadores = await _detalleModificadoresService.GetAllDetalleModificadoresAsync();
            return Ok(detalleModificadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleModificadorDTO>> GetDetalleModificador(int id)
        {
            var detalleModificador = await _detalleModificadoresService.GetDetalleModificadorByIdAsync(id);
            if (detalleModificador == null)
            {
                return NotFound();
            }
            return Ok(detalleModificador);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleModificadorDTO>> PostDetalleModificador(DetalleModificadorDTO detalleModificadorDto)
        {
            var createdDetalleModificador = await _detalleModificadoresService.CreateDetalleModificadorAsync(detalleModificadorDto);
            return CreatedAtAction(nameof(GetDetalleModificador), new { id = createdDetalleModificador.Id }, createdDetalleModificador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleModificador(int id, DetalleModificadorDTO detalleModificadorDto)
        {
            if (id != detalleModificadorDto.Id)
            {
                return BadRequest();
            }

            await _detalleModificadoresService.UpdateDetalleModificadorAsync(detalleModificadorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleModificador(int id)
        {
            await _detalleModificadoresService.DeleteDetalleModificadorAsync(id);
            return NoContent();
        }
    }
}