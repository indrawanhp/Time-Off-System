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
    public class AccountRolesController : BaseController<AccountRoleRepositories, AccountRoles, int>
    {
        public AccountRolesController(AccountRoleRepositories repo) : base(repo)
        {
        }
    }
}
