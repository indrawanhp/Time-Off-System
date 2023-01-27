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
    /*[Authorize(Roles = "Manager")]*/
    public class JobPlacementsController : BaseController<JobPlacementRepositories, JobPlacements, int>
    {
        private readonly JobPlacementRepositories _repo;

        public JobPlacementsController(JobPlacementRepositories repo) : base(repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("JobPlacementMaster")]
        public ActionResult JobPlacementMaster()
        {
            try
            {
                var result = _repo.GetMaster();
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
