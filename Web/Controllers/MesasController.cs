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
    public class MesasController : ControllerBase
    {
        private readonly IMesasService _mesasService;

        public MesasController(IMesasService mesasService)
        {
            _mesasService = mesasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesaDTO>>> GetMesas()
        {
            var mesas = await _mesasService.GetAllMesasAsync();
            return Ok(mesas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MesaDTO>> GetMesa(int id)
        {
            var mesa = await _mesasService.GetMesaByIdAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }
            return Ok(mesa);
        }

        [HttpPost]
        public async Task<ActionResult<MesaDTO>> PostMesa(MesaDTO mesaDto)
        {
            var createdMesa = await _mesasService.CreateMesaAsync(mesaDto);
            return CreatedAtAction(nameof(GetMesa), new { id = createdMesa.Id }, createdMesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, MesaDTO mesaDto)
        {
            if (id != mesaDto.Id)
            {
                return BadRequest();
            }

            await _mesasService.UpdateMesaAsync(mesaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            await _mesasService.DeleteMesaAsync(id);
            return NoContent();
        }
    }
}