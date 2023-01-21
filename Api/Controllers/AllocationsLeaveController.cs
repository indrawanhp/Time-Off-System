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
    [Authorize(Roles = "Admin, Manager")]
    public class AllocationsLeaveController : BaseController<AllocationLeaveRepositories, AllocationLeave, int>
    {
        public AllocationsLeaveController(AllocationLeaveRepositories repo) : base(repo)
        {
        }
    }
}
