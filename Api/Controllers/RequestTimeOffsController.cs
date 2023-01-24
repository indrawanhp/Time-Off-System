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
    //[Authorize(Roles = "Employee, Manager")]
    public class RequestTimeOffsController : BaseController<RequestTimeOffRepositories, RequestTimeOff, int>
    {
        public RequestTimeOffsController(RequestTimeOffRepositories repo) : base(repo)
        {
        }
    }
}
