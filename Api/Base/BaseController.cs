using Api.Controllers;
using Api.Models;
using Api.Repositories.Data;
using Api.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<Repository, Entity, TId> : ControllerBase
    where Entity : class
    where Repository : IRepository<Entity, TId>
{
    private Repository _repo;

    public BaseController(Repository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var result = _repo.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }

    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetById(TId id)
    {
        try
        {
            var result = _repo.Get(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }
    }

    [HttpPost]
    public ActionResult Insert(Entity entity)
    {
        try
        {
            var result = _repo.Insert(entity);
            return result == 0 ? Ok(new { statusCode = 204, message = "Data failed to Insert!" }) :
            Ok(new { statusCode = 201, message = "Data Saved Succesfully!" });
        }
        catch
        {
            return BadRequest(new { statusCode = 500, message = "" });
        }
    }

    [HttpPut]
    public ActionResult Update(Entity entity)
    {
        try
        {
            var result = _repo.Update(entity);
            return result == 0 ?
            Ok(new { statusCode = 204, message = $"Id not found!" })
          : Ok(new { statusCode = 201, message = "Update Succesfully!" });
        }
        catch
        {
            return BadRequest(new { statusCode = 500, message = "Something Wrong!" });
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(TId id)
    {
        try
        {
            var result = _repo.Delete(id);
            return result == 0 ? Ok(new { statusCode = 204, message = $"Id {id} Data Not Found" }) :
            Ok(new { statusCode = 201, message = "Data Delete Succesfully!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong {e.Message}" });
        }
    }
}
