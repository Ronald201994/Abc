using Abc.Domain.Common;

namespace Abc.Domain.Entities;
public class Usuario : BaseDomainModel
{
    public string NombreUsuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string? Email { get; set; }

    public int RoleId { get; set; }

    public int EmpleadoId { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
