using application_session.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace application_session.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            _logger.LogInformation("Page Login affichée.");
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if (vm.Username == "admin" && vm.Password == "1234")
            {
                HttpContext.Session.SetString("isLogged", "true");
                _logger.LogInformation("Utilisateur connecté : {Username}", vm.Username);
                return RedirectToAction("Add", "Todos");
            }

            _logger.LogWarning("Échec de login avec Username : {Username}", vm.Username);
            ViewBag.Error = "Username ou mot de passe incorrect !";
            return View();
        }

        public IActionResult Logout()
        {
            _logger.LogInformation("Utilisateur déconnecté.");
            HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction(nameof(Login));
        }
    }
}
