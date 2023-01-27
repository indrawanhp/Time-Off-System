using Api.Models;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : BaseController<Employee, EmployeeRepository, int>
{
    private EmployeeRepository _repository;
    public AdminController(EmployeeRepository repository) : base(repository)
    {
        _repository = repository;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EmployeeManagement()
    {
        return View();
    }

    public IActionResult Account()
    {
        return View();
    }
    public IActionResult AllocationsLeave()
    {
        return View();
    }
}
