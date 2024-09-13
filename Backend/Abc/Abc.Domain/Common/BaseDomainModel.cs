namespace Abc.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public bool? Activo { get; set; }

        public string? UsuarioCreacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
