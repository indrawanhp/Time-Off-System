﻿using Client.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Client.Base;

public class BaseController<Entity, Repository, TId> : Controller
    where Entity : class
    where Repository : IRepository<Entity, TId>
{
    private readonly Repository repository;
    public BaseController(Repository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public async Task<JsonResult> GetAll()
    {
        var result = await repository.Get();
        return Json(result);
    }

    [HttpGet]
    public async Task<JsonResult> Get(TId id)
    {
        var result = await repository.Get(id);
        return Json(result);
    }

    [HttpPost]
    public JsonResult Post(Entity entity)
    {
        var result = repository.Post(entity);
        return Json(result);
    }

    [HttpPut]
    public JsonResult Put(Entity entity)
    {
        var result = repository.Put(entity);
        return Json(result);
    }

    [HttpDelete]
    public JsonResult Delete(TId id)
    {
        var result = repository.Delete(id);
        return Json(result);
    }
}
