using Abc.Application.Dtos;
using Abc.Application.Features.Empleados.Commands.Crear;
using Abc.Domain.Entities;
using AutoMapper;

namespace Abc.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Empleado, EmpleadoDto>()
            .ForMember(dest => dest.NombreCargo, opt => opt.MapFrom(src => src.Cargo.Nombre))
            .ForMember(dest => dest.NombreAfp, opt => opt.MapFrom(src => src.Afp.Nombre));

            CreateMap<CrearEmpleadoCommand, Empleado>();
        }
    }
}
