using SistemaGestionOfertas.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionOfertas.Models.JobOffers
{
    /// <summary>
    /// Clase que representa la informacion de una oferta en el sistema.
    /// </summary>
    public class JobOffer
    {
        /// <summary>
        /// Identificador único de la oferta.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Titulo de la oferta.
        /// </summary>
        [Required, StringLength(100)]
        public required string Title { get; set; }

        /// <summary>
        /// Descripción de la oferta.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Indica si la oferta fue eliminada lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Dirección del lugar de la oferta.
        /// </summary>
        [StringLength(100)]
        public string? Address { get; set; }

        /// <summary>
        /// Indica si se debe ocultar el salario en la publicación.
        /// </summary>
        public bool HideSalary { get; set; } = false;

        /// <summary>
        /// Fecha y hora de publicación de la oferta.
        /// </summary>
        public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// Fecha y hora de expiración de la oferta.
        /// </summary>
        public DateTime? ExpiredAt { get; set; }

        /// <summary>
        /// Fecha y hora de creación del registro.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        #region ForeingKeys
        /// <summary>
        /// Identificador de la ciudad de la oferta.
        /// </summary>
        public int IdCity { get; set; }

        /// <summary>
        /// Identificador del rango salarial de la oferta.
        /// </summary>
        public int IdSalary { get; set; }

        /// <summary>
        /// Identificador del tipo de contrato de la oferta.
        /// </summary>
        public int IdContractType { get; set; }

        /// <summary>
        /// Identificador del tiempo de expiración de la oferta.
        /// </summary>
        public int IdExpirationTime { get; set; }

        /// <summary>
        /// ID del usuario que registró la oferta.
        /// </summary>
        public int IdUserWhoRegisteredIt { get; set; }

        /// <summary>
        /// ID del usuario que modificó la oferta.
        /// </summary>
        public int? IdUserWhoModifiedIt { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// Representa la relación de navegación entre la oferta y su ciudad.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>City</c> asociado a esta oferta.
        /// </remarks>
        [ForeignKey("IdCity")]
        public virtual City? City { get; set; }

        /// <summary>
        /// Representa la relación de navegación entre la oferta y el salario.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>Salary</c> asociado a esta oferta.
        /// </remarks>
        [ForeignKey("IdSalary")]
        public virtual Salary? Salary { get; set; }

        /// <summary>
        /// Representa la relación de navegación entre la oferta y el tipo de contrato.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>ContractType</c> asociado a esta oferta.
        /// </remarks>
        [ForeignKey("IdContractType")]
        public virtual ContractType? ContractType { get; set; }

        /// <summary>
        /// Representa la relación de navegación entre la oferta y el tiempo de expiración.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>ExpirationTime</c> asociado a esta oferta.
        /// </remarks>
        [ForeignKey("IdExpirationTime")]
        public virtual ExpirationTime? ExpirationTime { get; set; }

        /// <summary>
        /// Representa la relación de navegación entre la oferta y el usuario que la creó.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>User</c> asociado a esta oferta.
        /// </remarks>
        [ForeignKey("IdUserWhoRegisteredIt")]
        public virtual User? UserWhoRegisteredIt { get; set; }

        /// <summary>
        /// Representa la relación de navegación entre la oferta y el usuario que la modifica.
        /// </summary>
        /// <remarks>
        /// Esta propiedad permite acceder al objeto <c>User</c> asociado a esta oferta.
        /// </remarks>
        [ForeignKey("IdUserWhoModifiedIt")]
        public virtual User? UserWhoModifiedIt { get; set; }
        #endregion
    }
}
