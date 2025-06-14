using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.Users
{
    /// <summary>
    /// Clase que representa la informacion de un usuario en el sistema.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
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
