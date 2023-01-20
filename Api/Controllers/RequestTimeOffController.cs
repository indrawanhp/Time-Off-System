using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTimeOffController : BaseController<RequestTimeOffRepositories, RequestTimeOff, int>
    {
        public RequestTimeOffController(RequestTimeOffRepositories repo) : base(repo)
        {
        }
    }
}
