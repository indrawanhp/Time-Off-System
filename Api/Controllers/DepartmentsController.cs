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
    //[Authorize(Roles = "Admin")]
    public class DepartmentsController : BaseController<DepartmentRepositories, Department, int>
    {
        public DepartmentsController(DepartmentRepositories repo) : base(repo)
        {
        }
    }
}
