using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion de una ciudad en el sistema.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Identificador único de la ciudad.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la Ciudad.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Indicador de que la ciudad tiene borrado logico.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Indentificador unico del departamento al que corresponde la ciudad.
        /// </summary>
        public int IdDepartment { get; set; }

        /// <summary>
        /// Representa la relación de navegación entre la ciudad y su departamento.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>Department</c> asociado a esta ciudad.
        /// </remarks>
        [ForeignKey("IdDepartment")]
        public virtual Department? Department { get; set; }
    }
}
