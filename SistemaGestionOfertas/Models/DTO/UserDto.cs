using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.DTO
{
    /// <summary>
    /// Clase que representa un objeto de transferencia de datos (DTO) para un usuario.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        [EmailAddress(ErrorMessage = "El campo Email no es una dirección de correo electrónico válida")]
        public required string Email { get; set; }
        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// fecha de creacion del usuario.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// fecha de actualización del usuario.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// Rol del usuario.
        /// </summary>
        public required string Role { get; set; }
    }
}
