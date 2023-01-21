using Api.Models;
using Api.ViewModels;
using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : BaseController<Accounts, LoginRepository, int>
    {
        private readonly LoginRepository repository;
        private IConfiguration con;

        public HomeController(LoginRepository repository, IConfiguration con) : base(repository)
        {
            this.repository = repository;
            this.con = con;
        }

        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwtToken = await repository.Auth(login);
            var token = jwtToken.data;

            if (token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpContext.Session.SetString("JWToken", token);
            //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
            //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");

            return RedirectToAction("index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}