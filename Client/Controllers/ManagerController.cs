using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize]

    public class ManagerController : Controller
    {
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
                return View();
        }
        public IActionResult ListJobAndDepartment()
        {
            return View();
        }
    }
}
