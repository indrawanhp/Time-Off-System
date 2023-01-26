using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize]

    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Account()
        {
            return View();
        }
        public IActionResult AllocationsLeave()
        {
            return View();
        }
    }
}
