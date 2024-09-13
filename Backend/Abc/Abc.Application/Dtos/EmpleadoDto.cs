namespace Abc.Application.Dtos
{
    public record EmpleadoDto()
    {
        public int Id { get; init; }
        public string Nombre { get; init; } = null!;
        public string Apellidos { get; init; } = null!;
        public int CargoId { get; init; }
        public string NombreCargo { get; init; } = null!;
        public int AfpId { get; init; }
        public string NombreAfp { get; init; } = null!;
        public DateTime? FechaNacimiento { get; init; }
        public DateTime? FechaIngreso { get; init; }
        public decimal? Sueldo { get; init; }
    }
}
