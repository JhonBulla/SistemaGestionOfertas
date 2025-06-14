namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar un tipo de contrato.
    /// </summary>
    public class ContractTypeDto
    {
        /// <summary>
        /// Identificador único del tipo de contrato.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del tipo de contrato.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Indica si el tipo de contrato ha sido eliminado lógicamente.
        /// </summary>
        public int? DeletedKey { get; set; }
    }
}
