using Abc.Domain.Common;

namespace Abc.Domain.Entities;
public class Empleado : BaseDomainModel
{
    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public decimal? Sueldo { get; set; }

    public int CargoId { get; set; }

    public int AfpId { get; set; }

    public virtual Afp Afp { get; set; } = null!;

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
