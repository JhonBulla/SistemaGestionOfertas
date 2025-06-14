using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionOfertas.Models.DTO;
using SistemaGestionOfertas.Models.Interfaces;
using System.Security.Claims;

namespace SistemaGestionOfertas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository userRepository;

        public LoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: LoginController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginController/Create
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
