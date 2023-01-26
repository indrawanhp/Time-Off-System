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
    [Authorize(Roles = "Manager")]
    public class JobsController : BaseController<JobRepositories, Jobs, int>
    {
        public JobsController(JobRepositories repo) : base(repo)
        {
        }
    }
}
