using Api.Models;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize]

    public class AdminController : BaseController<Accounts, AccountRepository, int>
    {
        private readonly AccountRepository repository;
        public AdminController(AccountRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        //CreateAccount
        public IActionResult CreateAccount()
        {
            return View();
        }

        //CreateRole
        public IActionResult CreateRole()
        {
            return View();
        }

        //Total Time Off Employee
        public IActionResult TotalTimeOff()
        {
            return View();
        }
    }
}
