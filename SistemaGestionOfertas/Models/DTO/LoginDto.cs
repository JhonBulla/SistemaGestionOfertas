using System.ComponentModel.DataAnnotations;

namespace SistemaGestionOfertas.Models.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; } = null!;
    }
}
