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
    //[Authorize(Roles = "Manager")]
    public class JobPlacementsController : BaseController<JobPlacementRepositories, JobPlacements, int>
    {
        public JobPlacementsController(JobPlacementRepositories repo) : base(repo)
        {
        }
    }
}
