using Abc.Application.Dtos;
using MediatR;

namespace Abc.Application.Features.Empleados.Queries.Obtener
{
    public class ObtenerEmpleadoListQuery : IRequest<List<EmpleadoDto>>
    {
    }
}
