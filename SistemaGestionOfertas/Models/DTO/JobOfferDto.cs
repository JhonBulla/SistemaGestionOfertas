using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) para representar una oferta de empleo.
    /// </summary>
    public class JobOfferDto
    {
        /// <summary>
        /// Identificador único de la oferta.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título de la oferta.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción de la oferta.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Indica si la oferta fue eliminada lógicamente.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Dirección del lugar de la oferta.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Indica si se debe ocultar el salario en la publicación.
        /// </summary>
        public bool HideSalary { get; set; }

        /// <summary>
        /// Identificador de la ciudad de la oferta.
        /// </summary>
        public int IdCity { get; set; }

        /// <summary>
        /// Nombre de la ciudad de la oferta.
        /// </summary>
        public string? CityName { get; set; }

        /// <summary>
        /// Identificador del rango salarial de la oferta.
        /// </summary>
        public int IdSalary { get; set; }

        /// <summary>
        /// Rango salarial de la oferta.
        /// </summary>
        public string? SalaryRange { get; set; }

        /// <summary>
        /// Identificador del tipo de contrato de la oferta.
        /// </summary>
        public int IdContractType { get; set; }

        /// <summary>
        /// Tipo de contrato de la oferta.
        /// </summary>
        public string? ContractTypeName { get; set; }

        /// <summary>
        /// Identificador del tiempo de expiración de la oferta.
        /// </summary>
        public int IdExpirationTime { get; set; }

        /// <summary>
        /// Rango del tiempo de expiración de la oferta.
        /// </summary>
        public int ExpirationTimeRange { get; set; }

        /// <summary>
        /// tiempo de expiracion de la oferta.
        /// </summary>
        public string? ExpirationTimeName { get; set; }

        /// <summary>
        /// ID del usuario que registró la oferta.
        /// </summary>
        public int? IdUserWhoRegisteredIt { get; set; }

        /// <summary>
        /// ID del usuario que modificó la oferta.
        /// </summary>
        public int? IdUserWhoModifiedIt { get; set; }

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

    }
}
