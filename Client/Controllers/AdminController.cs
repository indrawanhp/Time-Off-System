using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
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
