using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion del salario en el sistema.
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// Identificador único del salario.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Descripción del Rango salarial.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Rango salarial.
        /// </summary>
        public string? Range { get; set; } 
        /// <summary>
        /// Indicador de que el tipo de contrato tiene borrado logico.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
