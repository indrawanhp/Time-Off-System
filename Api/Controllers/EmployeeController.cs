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
    public class EmployeeController : BaseController<EmployeeRepositories, Employee, int>
    {
        public EmployeeController(EmployeeRepositories repo) : base(repo)
        {
        }
    }
}
