using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        public AccountController(AccountRepositories repo, IConfiguration con) : base(repo)
        {
            _repo = repo;
            _con = con;
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var result = _repo.Login(loginVM);
                switch (result)
                {
                    case 0:
                        return Ok(new { statusCode = 200, message = "Account Not Found!" });
                    case 1:
                        return Ok(new { statusCode = 200, message = "Wrong Password!" });
                    case 2:
                        return Ok(new { statusCode = 200, message = "Login Success!"});

                    default:
                      return Ok(new { statusCode = 401, message = "Login Gagal!"});
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }

        }
    }
}
