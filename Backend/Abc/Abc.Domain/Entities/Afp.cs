using Abc.Domain.Common;

namespace Abc.Domain.Entities;
public class Afp : BaseDomainModel
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
