namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar un rango salarial.
    /// </summary>
    public class SalaryDto
    {
        /// <summary>
        /// Identificador único del rango salarial.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del rango salarial.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Rango salarial.
        /// </summary>
        public string? Range { get; set; }

        /// <summary>
        /// Indica si el rango salarial ha sido eliminado lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
