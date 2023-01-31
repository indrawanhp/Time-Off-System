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
                return Ok(result);
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
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }

        [HttpGet]
        [Route("MasterEmployee")]
        public ActionResult MasterEmployee()
        {
            try
            {
                var result = _repo.MasterEmployee();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }

        [HttpGet]
        [Route("GetNameManager")]
        public ActionResult GetManagerName()
        {
            try
            {
                var result = _repo.ManagerName();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }

		[HttpGet]
		[Route("GetSubordinateManager")]
		public ActionResult GetSubordinateManager()
		{
			try
			{
				var result = _repo.SubordinateManager();
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
			}
		}

		[HttpGet]
        [Route("GetSubordinates/{id}")]
        public ActionResult GetSubordinatesGetSubordinates(int id)
        {
            try
            {
                var result = _repo.GetSubordinates(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }
    }
}
