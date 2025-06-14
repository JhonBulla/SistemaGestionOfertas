using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion de un departamento en el sistema.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Identificador único del departamento.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del Departamento.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Indicador de que el departamento tiene borrado logico.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Indentificador unico del país al que corresponde la ciudad.
        /// </summary>
        public int Idcountry { get; set; }
        /// <summary>
        /// Representa la relación de navegación entre el departamento y su país.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>Country</c> asociado al departamento.
        /// </remarks>
        [ForeignKey("IdCountry")]
        public virtual Country? Country { get; set; }

        /// <summary>
        /// Representa la colección de ciudades asociados al departamento.
        /// </summary>
        /// <remarks>
        /// Esta propiedad define una relación uno-a-muchos entre el departamento y sus ciudades.
        /// Sirve para mapear la relación de navegación inversa desde la entidad <c>City</c>.
        /// </remarks>
        public ICollection<City>? Cities { get; set; }
    }
}
