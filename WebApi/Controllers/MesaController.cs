using Business.Intefaces.SGeneric;
using Data.Intefaces.IGeneric;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class MesaController : ControllerBase
    {

        private readonly ISGeneric<Mesa, MesaDTO> _Servicio;
        public MesaController(ISGeneric<Mesa, MesaDTO> servicio)
        {
            _Servicio = servicio;
        }

        // GET: api/mesa
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MesaDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            // El controlador solo llama al servicio y devuelve la respuesta
            var listaDTOs = await _Servicio.GetAllService();
            return Ok(listaDTOs); // Devuelve 200 OK + la lista en JSON
        }

        // GET: api/mesa/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MesaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _Servicio.GetByIdService(id);
            if (dto == null)
            {
                return NotFound(); // Devuelve 404 Not Found
            }
            return Ok(dto); // Devuelve 200 OK + el objeto en JSON
        }

        // POST: api/mesa
        [HttpPost]
        [ProducesResponseType(typeof(MesaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] MesaDTO dto)
        {
            // [FromBody] le dice a .NET que busque el objeto en el "cuerpo" del JSON
            var nuevoDto = await _Servicio.CreateService(dto);

            // Devuelve un 201 Created, la URL para encontrarlo, y el objeto creado
            return CreatedAtAction(nameof(GetById), new { id = nuevoDto.Id }, nuevoDto);
        }

        // PUT: api/mesa
        [HttpPut]
        [ProducesResponseType(typeof(MesaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] MesaDTO dto)
        {
            var dtoActualizado = await _Servicio.UpdateService(dto);
            return Ok(dtoActualizado); // Devuelve 200 OK + el objeto actualizado
        }

        // DELETE: api/mesa/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _Servicio.DeleteService(id);
            if (!resultado)
            {
                return NotFound(); // Devuelve 404 si no lo encontró
            }
            return NoContent(); // Devuelve 204 No Content (significa "borrado con éxito")
        }
    }
}
