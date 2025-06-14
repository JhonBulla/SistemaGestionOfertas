using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion de un tipo de contrato en el sistema.
    /// </summary>
    public class ContractType
    {
        /// <summary>
        /// Identificador único del tipo de contrato.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Tipo de contrato.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Indicador de que el tipo de contrato tiene borrado logico.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
