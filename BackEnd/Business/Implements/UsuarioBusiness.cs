using AutoMapper;
using Business.Implements.LogicaGenerica;
using Business.Intefaces;
using Data.Intefaces;
using Entity.DTOs;
using Entity.Model;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class UsuarioBusiness : SModeloGenerico<Usuario, UsuarioDTO>, IUsuarioBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsuarioBusiness(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Coincide exactamente con la interfaz: nombre y retorno (UsuarioDTO)
        public async Task<UsuarioDTO> ValidarCredenciales(string correo, string contrasena)
        {
            var usuario = await _userRepository.GetByCredencialesAsync(correo, contrasena);
            if (usuario == null) return null;
            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}