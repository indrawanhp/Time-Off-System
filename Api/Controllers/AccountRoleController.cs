using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountRoleController : BaseController<AccountRoleRepositories, AccountRoles, int>
    {
        public AccountRoleController(AccountRoleRepositories repo) : base(repo)
        {
        }
    }
}
