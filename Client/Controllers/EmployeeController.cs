﻿using Api.Models;
using Client.Base;
using Client.Repositories.Data;
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class EmployeeController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository repository;
        public EmployeeController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
