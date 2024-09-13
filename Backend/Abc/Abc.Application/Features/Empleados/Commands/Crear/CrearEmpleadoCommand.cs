using MediatR;

namespace Abc.Application.Features.Empleados.Commands.Crear
{
    public record CrearEmpleadoCommand(
        string Nombre,
        string Apellidos,
        int CargoId,
        int AfpId,
        DateTime? FechaNacimiento = null,
        DateTime? FechaIngreso = null,
        decimal? Sueldo = null
    ): IRequest<int>;
}
