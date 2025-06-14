namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar un departamento.
    /// </summary>
    public class DepartmentDto
    {
        /// <summary>
        /// Identificador único del departamento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del departamento.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Identificador del país al que pertenece el departamento.
        /// </summary>
        public int IdCountry { get; set; }

        /// <summary>
        /// Indica si el departamento ha sido eliminado lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
