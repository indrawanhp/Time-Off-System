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

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
/*[Authorize(Roles = "Admin")]*/
public class AccountsController : BaseController<AccountRepositories, Accounts, int>
{
    private AccountRepositories _repositories;
    private IConfiguration _config;
    public AccountsController(AccountRepositories repo, IConfiguration con) : base(repo)
    {
        _repositories = repo;
        _config = con;
    }

    [HttpPost]
    [Route("Register")]
    public ActionResult Register(RegisterVM registerVM)
    {
        try
        {
            var result = _repositories.Register(registerVM);
            return result == 0 
                ? BadRequest(new { statusCode = 204, message = "Email or Phone is Already Registered!" }) 
                : Ok(new { statusCode = 201, message = "Register Succesfully!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }
    }

    [HttpGet]
    [Route("AccountMaster")]
    public ActionResult AccountMaster()
    {
        try
        {
            var result = _repositories.AccountMaster();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }
    }

    [HttpPost]
    [Route("ChangePassword")]
    [AllowAnonymous]
    public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
    {
        var data = _repositories.ChangePassword(changePasswordVM);
        if (data == 1)
        {
            return Ok(new { statusCode = 200, message = "Success change user password" });
        }
        return BadRequest(new { statusCode = 400, message = "Failed change user password" });

    }

    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public ActionResult Login(LoginVM loginVM)
    {
        try
        {
            var result = _repositories.Login(loginVM);
            switch(result)
            {
                case 0: 
                    return Ok(new { message = "Account Not Found"});
                case 1:
                    return Ok(new { message = "Wrong Password"});
                default:
                    var roles = _repositories.UserRoles(loginVM.Email);
                    var id = _repositories.userID(loginVM.Email);

                    var claims = new List<Claim>()
                    {
                        new Claim("email", loginVM.Email),
                        new Claim("id", id.ToString())
                    };

                    foreach(var item in roles)
                    {
                        claims.Add(new Claim("role", item));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["JWT:Issuer"],
                        _config["JWT:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signIn
                        );

                    var generateToken = new JwtSecurityTokenHandler().WriteToken(token);
                    claims.Add(new Claim("Token Security", generateToken.ToString()));

                    return Ok(new { statusCode = 200, message = "Login Success!", data = generateToken});
            }
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }
    }
}
