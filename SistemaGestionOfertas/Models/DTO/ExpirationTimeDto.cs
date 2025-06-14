namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar el tiempo de expiración de una oferta.
    /// </summary>
    public class ExpirationTimeDto
    {
        /// <summary>
        /// Identificador único del tiempo de expiración.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del tiempo de expiración (por ejemplo, "1 semana", "30 días").
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Indica si el tiempo de expiración ha sido eliminado lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
