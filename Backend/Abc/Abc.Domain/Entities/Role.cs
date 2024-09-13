using Abc.Domain.Common;

namespace Abc.Domain.Entities;
public class Role : BaseDomainModel
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
