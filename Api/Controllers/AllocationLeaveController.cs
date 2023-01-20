﻿using Api.Base;
using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationLeaveController : BaseController<AllocationLeaveRepositories, AllocationLeave, int>
    {
        public AllocationLeaveController(AllocationLeaveRepositories repo) : base(repo)
        {
        }
    }
}