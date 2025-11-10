using Business.Intefaces.SGeneric;
using Entity.DTOs;
using Entity.Model;
using System.Threading.Tasks;

namespace Business.Intefaces
{
    public interface IUsuarioBusiness : ISGeneric<Usuario, UsuarioDTO>
    {
        // Ahora retorna correctamente UsuarioDTO
        Task<UsuarioDTO> ValidarCredenciales(string correo, string contrasena);
    }
}