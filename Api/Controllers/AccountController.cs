using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<AccountRepositories, Accounts, int>
    {
        public AccountController(AccountRepositories repo) : base(repo)
        {
        }
    }
}
