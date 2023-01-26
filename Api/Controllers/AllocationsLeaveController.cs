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
/*    [Authorize(Roles = "Admin, Manager")]
*/    public class AllocationsLeaveController : BaseController<AllocationLeaveRepositories, AllocationLeave, int>
    {
        private AllocationLeaveRepositories _repositories;
        private IConfiguration _config;
        public AllocationsLeaveController(AllocationLeaveRepositories repo, IConfiguration con) : base(repo)
        {
            _repositories = repo;
            _config = con;
        }

        [HttpGet]
        [Route("AllocationLeaveMasters")]
        public ActionResult AllocationLeaveMasters()
        {
            try
            {
                var result = _repositories.AllocationLeaveMasters();
                return result.Count() == 0
                ? BadRequest(new { statusCode = 204, message = "Data Not Found!" })
                : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
            }
        }

    }
}
