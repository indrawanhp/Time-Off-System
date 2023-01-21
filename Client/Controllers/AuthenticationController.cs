using Api.Models;
using Api.ViewModels;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AuthenticationController : BaseController<Accounts, AuthenticationRepository, int>
    {
        private readonly AuthenticationRepository repository;
        private IConfiguration con;

        public AuthenticationController(AuthenticationRepository repository, IConfiguration con) : base(repository)
        {
            this.repository = repository;
            this.con = con;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwtToken = await repository.Auth(login);
            var token = jwtToken.data;
            var role = jwtToken.Roles;

            if (token == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("Roles", role);

            if (role == "Admin")
            {
                return RedirectToAction("index", "Admin");
            }
            else if (role == "Manager")
            {
                return RedirectToAction("index", "Manager");
            }
            else if (role == "Employee")
            {
                return RedirectToAction("index", "Employee");
            }
            else
            {
                return RedirectToAction("index", "Authentication");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }

        public IActionResult Login()
        {
            return View(); 
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet("Unauthorized/")]
        public IActionResult Unauthorized()
        {
            return View("401");
        }

        [HttpGet("Forbidden/")]
        public IActionResult Forbidden()
        {
            return View("403");
        }
        [HttpGet("Notfound/")]
        public IActionResult Notfound()
        {
            return View("404");
        }
    }
}
