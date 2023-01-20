using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepositories, Department, int>
    {
        public DepartmentController(DepartmentRepositories repo) : base(repo)
        {
        }
    }
}
