using Microsoft.AspNetCore.Mvc;
using WebApi.Jwt;
using Business.Intefaces; // Para IUsuarioBusiness
using Entity.DTOs;       // Para UsuarioDTO

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioBusiness _usuarioBusiness; // Inyectamos el servicio real

        public AuthController(ITokenService tokenService, IUsuarioBusiness usuarioBusiness)
        {
            _tokenService = tokenService;
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpPost("login")]
        public async Task<ActionResult<object>> Login([FromBody] LoginDTO loginDto)
        {
            // 1. Validar que el DTO no venga vacío
            if (loginDto == null) return BadRequest("Datos de login inválidos");

            // 2. Llamar a la capa de Negocio para validar credenciales
            UsuarioDTO usuario = await _usuarioBusiness.ValidarCredenciales(loginDto.Email, loginDto.Password);

            // 3. Si devuelve null, es que el correo o contraseña están mal
            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos" });
            }

            // 4. Si todo está bien, generamos el token usando los datos REALES del usuario
            var token = _tokenService.CreateToken(usuario.Id, usuario.Email);

            // 5. Devolvemos el token al cliente
            return Ok(new { token = token });
        }
    }
}