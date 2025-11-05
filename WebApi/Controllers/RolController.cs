using Business.Intefaces.SGeneric;
using Data.Intefaces.IGeneric;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {

        private readonly ISGeneric<Rol, RolDTO> _Servicio;
        public RolController(ISGeneric<Rol, RolDTO> servicio)
        {
            _Servicio = servicio;
        }

        // GET: api/rol
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // El controlador solo llama al servicio y devuelve la respuesta
            var listaDTOs = await _Servicio.GetAllService();
            return Ok(listaDTOs); // Devuelve 200 OK + la lista en JSON
        }

        // GET: api/rol/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _Servicio.GetByIdService(id);
            if (dto == null)
            {
                return NotFound(); // Devuelve 404 Not Found
            }
            return Ok(dto); // Devuelve 200 OK + el objeto en JSON
        }

        // POST: api/rol
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDTO dto)
        {
            // [FromBody] le dice a .NET que busque el objeto en el "cuerpo" del JSON
            var nuevoDto = await _Servicio.CreateService(dto);

            // Devuelve un 201 Created, la URL para encontrarlo, y el objeto creado
            return CreatedAtAction(nameof(GetById), new { id = nuevoDto.Id }, nuevoDto);
        }

        // PUT: api/rol
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RolDTO dto)
        {
            var dtoActualizado = await _Servicio.UpdateService(dto);
            return Ok(dtoActualizado); // Devuelve 200 OK + el objeto actualizado
        }

        // DELETE: api/rol/5
        [HttpDelete("{id}")]
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
