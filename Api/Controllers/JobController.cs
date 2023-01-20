using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController<JobRepositories, Jobs, int>
    {
        public JobController(JobRepositories repo) : base(repo)
        {
        }
    }
}
