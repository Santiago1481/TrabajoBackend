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
    public class ModificadoresController : ControllerBase
    {
        private readonly IModificadoresService _modificadoresService;

        public ModificadoresController(IModificadoresService modificadoresService)
        {
            _modificadoresService = modificadoresService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModificadoresDTO>>> GetModificadores()
        {
            var modificadores = await _modificadoresService.GetAllModificadoresAsync();
            return Ok(modificadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModificadoresDTO>> GetModificador(int id)
        {
            var modificador = await _modificadoresService.GetModificadorByIdAsync(id);
            if (modificador == null)
            {
                return NotFound();
            }
            return Ok(modificador);
        }

        [HttpPost]
        public async Task<ActionResult<ModificadoresDTO>> PostModificador(ModificadoresDTO modificadorDto)
        {
            var createdModificador = await _modificadoresService.CreateModificadorAsync(modificadorDto);
            return CreatedAtAction(nameof(GetModificador), new { id = createdModificador.Id }, createdModificador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificador(int id, ModificadoresDTO modificadorDto)
        {
            if (id != modificadorDto.Id)
            {
                return BadRequest();
            }

            await _modificadoresService.UpdateModificadorAsync(modificadorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModificador(int id)
        {
            await _modificadoresService.DeleteModificadorAsync(id);
            return NoContent();
        }
    }
}