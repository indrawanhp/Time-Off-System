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
    //[Authorize]
    public class EmployeesController : BaseController<EmployeeRepositories, Employee, int>
    {
        private EmployeeRepositories _repo;
        public EmployeesController(EmployeeRepositories repo) : base(repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetRequestEmployee/{id}/{status}")]
        public ActionResult GetRequestEmployee(int id, Status status)
        {
            try
            {
                var result = _repo.EmployeeRequest(id, status);
                return result.Count() == 0
                ? Ok(result)
                : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }

        [HttpGet]
        [Route("GetRequestManager/{id}/{status}")]
        public ActionResult GetRequestManager(int id, Status status)
        {
            try
            {
                var result = _repo.ManangeEmploye(id, status);
                return result.Count() == 0
                ? Ok(result)
                : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }
    }
}
