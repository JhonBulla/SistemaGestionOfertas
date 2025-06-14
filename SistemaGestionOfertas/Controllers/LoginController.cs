using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionOfertas.Models.DTO;
using SistemaGestionOfertas.Models.Interfaces;
using System.Security.Claims;

namespace SistemaGestionOfertas.Controllers
{
    /// <summary>
    /// Representa el controlador de acciones para gestionar el logueo y los roles de usuarios
    /// </summary>
    public class LoginController : Controller
    {
        #region Properties
        /// <summary>
        /// Instancia de acceso al repositorio de datos para la entidad User
        /// </summary>
        private readonly IUserRepository userRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de LoginController.
        /// </summary>
        /// <param name="userRepository">Instancia de acceso al repositorio de usuarios</param>
        public LoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region CreateJobOffer

        #region Index
        /// <summary>
        /// Acción GET que muestra la vista de inicio de sesión para el usuario.
        /// </summary>
        /// <remarks>
        /// Este método responde a solicitudes GET y presenta el formulario de inicio de sesión.
        /// </remarks>
        /// <returns>La vista de inicio de sesión.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Login
        /// <summary>
        /// Acción POST que procesa la solicitud de inicio de sesión del usuario.
        /// </summary>
        /// <remarks>
        /// Este método autentica al usuario utilizando cookies de autenticación y redirige según su rol.
        /// </remarks>
        /// <param name="loginDto">Objeto que contiene las credenciales ingresadas por el usuario.</param>
        /// <returns>
        /// Si las credenciales son válidas, redirige al área correspondiente según el rol del usuario.
        /// Si las credenciales son inválidas, retorna la vista de inicio de sesión con un mensaje de error.
        /// Requiere un token antifalsificación (AntiForgeryToken) para mayor seguridad.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = userRepository.ValidateUser(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                ViewBag.LoginError = "Usuario o contraseña incorrectos";
                return View("Index", loginDto);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if(user.Role == "User")
            {
                return RedirectToAction("Index", "Joboffer");

            }
            return RedirectToAction("Admin", "Joboffer");
        }
        #endregion

        #region Logout
        /// <summary>
        /// Metodo POST que gierra la sesión del usuario autenticado y elimina la cookie de autenticación.
        /// </summary>
        /// <remarks>
        /// Este método invalida la sesión actual y redirige al usuario a la página de inicio de sesión.
        /// Requiere un token antifalsificación (AntiForgeryToken) para mayor seguridad.
        /// </remarks>
        /// <returns>Una redirección a la acción <c>Index</c> del controlador <c>Login</c>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        #endregion

        #endregion
    }
}
