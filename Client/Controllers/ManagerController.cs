using Api.Models;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Authorize(Roles = "Manager")]
public class ManagerController : BaseController<Employee, EmployeeRepository, int>
{
    private readonly EmployeeRepository _repository;
    private readonly RequestTimeOffRepository _requestRepo;
    private readonly AllocationLeaveRepository _allocationLeave;
    public ManagerController(EmployeeRepository repository, RequestTimeOffRepository requestRepo, AllocationLeaveRepository allocationLeave) : base(repository)
    {
        _repository = repository;
        _requestRepo = requestRepo;
        _allocationLeave = allocationLeave;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ListJobAndDepartment()
    {
        return View();
    }

    public IActionResult ManageTimeOff()
    {
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetRequestManager(int id, Status status)
    {
        var result = await _repository.GetRequestManager(id, status);
        return Json(result);
    }

    [HttpGet]
    public async Task<JsonResult> GetRequestById(int id)
    {
        var result = await _requestRepo.GetById(id);
        return Json(result);
    }

    [HttpPut]
    public JsonResult ResponseRequest([FromBody] RequestTimeOff timeOff)
    {
        var result = _requestRepo.Put(timeOff);
        return Json(result);
    }

    [HttpPut]
    public JsonResult UpdateRemainingLeave([FromBody] AllocationLeave allocationLeave)
    {
        var result = _allocationLeave.Put(allocationLeave);
        return Json(result);
    }
}
