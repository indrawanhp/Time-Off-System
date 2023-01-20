using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<AccountRepositories, Accounts, int>
    {
        private AccountRepositories _repo;
        private IConfiguration _con;
        public AccountController(AccountRepositories repo) : base(repo)
        {
        }
    }
}
