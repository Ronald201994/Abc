using Abc.Application.Contracts.Persistence;
using Abc.Domain.Entities;
using Abc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infrastructure.Repositories
{
    public class EmpleadoRepository(AbcContext context) : BaseRepository<Empleado>(context), IEmpleadoRepository
    {
        public async Task<IReadOnlyList<Empleado>> ObtenerEmpleadosListAsync()
        {
            var resultado = await context.Empleados
                                .Include(e => e.Cargo)
                                .Include(e => e.Afp).ToListAsync();

            return resultado;
        }
    }
}
