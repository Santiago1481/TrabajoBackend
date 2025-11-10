using AutoMapper;
using Entity.DTOs;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();

            CreateMap<RolUser, RolUserDTO>();
            CreateMap<RolUserDTO, RolUser>();

            CreateMap<Productos, ProductosDTO>();
            CreateMap<ProductosDTO, Productos>();

            CreateMap<Pedidos, PedidosDTO>();
            CreateMap<PedidosDTO, Pedidos>();

            CreateMap<Modificadores, ModificadoresDTO>();
            CreateMap<ModificadoresDTO, Modificadores>();

            CreateMap<Mesa, MesaDTO>();
            CreateMap<MesaDTO, Mesa>();

            CreateMap<DetalleModificador, DetalleModificadorDTO>();
            CreateMap<DetalleModificadorDTO, DetalleModificador>();


        }

    }
}
