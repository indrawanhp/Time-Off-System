using Api.Models;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace Client.Controllers;

[Authorize(Roles = "Employee")]
public class EmployeeController : BaseController<Employee, EmployeeRepository, int>
{
    private readonly EmployeeRepository repository;
    private readonly RequestTimeOffRepository _requestRepo;
    public EmployeeController(EmployeeRepository repository, RequestTimeOffRepository requestRepo) : base(repository)
    {
        this.repository = repository;
        this._requestRepo = requestRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult RequestTimeOff()
    {
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetRequestEmployee(int id, Status status)
    {
        var result = await repository.GetRequestEmployee(id, status);
        return Json(result);
    }

    [HttpGet]
    public async Task<JsonResult> GetRequestById(int id)
    {
        var result = await _requestRepo.GetById(id);
        return Json(result);
    }

    [HttpPut]
    public JsonResult PublishRequest([FromBody] RequestTimeOff timeOff)
    {
        var result = _requestRepo.Put(timeOff);
        return Json(result);
    }

    [HttpPost]
    public JsonResult InsertRequest([FromBody] RequestTimeOff timeOff)
    {
        var result = _requestRepo.Post(timeOff);
        return Json(result);
    }
}
