namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar una ciudad.
    /// </summary>
    public class CityDto
    {
        /// <summary>
        /// Identificador único de la ciudad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la ciudad.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Identificador del departamento al que pertenece la ciudad.
        /// </summary>
        public int IdDepartment { get; set; }

        /// <summary>
        /// Indica si la ciudad ha sido eliminada lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
