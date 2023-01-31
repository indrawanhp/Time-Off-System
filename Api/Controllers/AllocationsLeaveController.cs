using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin, Manager")]
public class AllocationsLeaveController : BaseController<AllocationLeaveRepositories, AllocationLeave, int>
{
    private AllocationLeaveRepositories _repo;
    public AllocationsLeaveController(AllocationLeaveRepositories repo) : base(repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Route("AllocationLeaveMasters")]
    public ActionResult AllocationLeaveMasters()
    {
        try
        {
            var result = _repo.AllocationLeaveMasters();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }
    }

    [HttpGet]
    [Route("GetEmployee/{id}")]
    public ActionResult GetEmployee(int id)
    {
        try
        {
            var result = _repo.GetEmployee(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }
    }

}
