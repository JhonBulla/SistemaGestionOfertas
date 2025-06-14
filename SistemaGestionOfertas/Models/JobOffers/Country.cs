using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion de un país en el sistema.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Identificador único del país.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del País.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Indicador de que el país tiene borrado logico.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Representa la colección de departamentos asociados al país.
        /// </summary>
        /// <remarks>
        /// Esta propiedad define una relación uno-a-muchos entre <c>Country</c> y <c>Department</c>.
        /// Sirve para mapear la relación de navegación inversa desde la entidad <c>Department</c>.
        /// </remarks>
        public ICollection<Department>? Departments { get; set; }
    }
}
