using Abc.Application.Dtos;
using Abc.Domain.Entities;

namespace Abc.Application.Contracts.Persistence
{
    public interface IEmpleadoRepository : IBaseRepository<Empleado>
    {
        Task<IReadOnlyList<Empleado>> ObtenerEmpleadosListAsync();
    }
}
