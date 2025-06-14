namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar un país.
    /// </summary>
    public class CountryDto
    {
        /// <summary>
        /// Identificador único del país.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del país.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Indica si el país ha sido eliminado lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
