using Api.Models;
using Api.ViewModels;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Controllers;

public class AuthenticationController : BaseController<Accounts, AuthenticationRepository, int>
{
    private readonly AuthenticationRepository repository;
    private IConfiguration con;

    public AuthenticationController(AuthenticationRepository repository, IConfiguration con) : base(repository)
    {
        this.repository = repository;
        this.con = con;
    }

    [HttpPost]
    public async Task<IActionResult> Auth(LoginVM login)
    {
        var jwtToken = await repository.Auth(login);
        var token = jwtToken.Data;
        var claim = ExtractClaims(token);
        var jwtPayload = new JwtPayload(claim);
        //var role = claim.Where(claim => claim.Type == "role").Select(claim => claim.Value).ToList();
        var role = jwtPayload.Claims.First(c => c.Type == "role").Value;
        var id = claim.FirstOrDefault(claim => claim.Type == "id")?.Value;

        if (token == null)
        {
            return RedirectToAction("Login", "Authentication");
        }

        //Response.Cookies.Append("token", token, new CookieOptions
        //{
        //    Expires = jwtPayload.ValidTo,
        //    HttpOnly = true,
        //    Secure = true, 
        //    IsEssential = true,
        //});

        HttpContext.Session.SetString("JWToken", token);
        HttpContext.Session.SetInt32("ID", int.Parse(id));

        if (role == "Admin")
        {
            return RedirectToAction("index", "Admin");
        }
        else if (role == "Manager")
        {
            return RedirectToAction("index", "Manager");
        }
        else if (role == "Employee")
        {
            return RedirectToAction("index", "Employee");
        }
        else
        {
            return RedirectToAction("index", "Authentication");
        }
    }

    public ActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Authentication");
    }

    public IActionResult Login()
    {
        return View(); 
    }
    public IActionResult Register()
    {
        return View();
    }


    [HttpGet("/Unauthorized")]
    public IActionResult Unauthorized()
    {
        return View("401");
    }

    [HttpGet("/Forbidden")]
    public IActionResult Forbidden()
    {
        return View("403");
    }

    [HttpGet("/Notfound")]
    public IActionResult Notfound()
    {
        return View("404");
    }

    public IEnumerable<Claim> ExtractClaims(string jwtToken)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);
        IEnumerable<Claim> claims = securityToken.Claims;
        return claims;
    }
}
