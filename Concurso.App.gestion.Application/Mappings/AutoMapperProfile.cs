using AutoMapper;
using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Domain.Entities;

namespace Concurso.App.gestion.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario.Nombre))
                .ReverseMap();
            CreateMap<DetallePedido, DetallePedidoDto>()
                .ForMember(dest => dest.ProductoNombre, opt => opt.MapFrom(src => src.Producto.Nombre))
                .ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
