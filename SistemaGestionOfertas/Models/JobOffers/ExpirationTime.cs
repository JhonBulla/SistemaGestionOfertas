using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion del tiempo de expiración de una oferta en el sistema.
    /// </summary>
    public class ExpirationTime
    {
        /// <summary>
        /// Identificador único del tiempo de expiración.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Descripción del tiempo de expiración.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Tiempo de expiración.
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// Indicador de que el tiempo de expiración tiene borrado logico.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
