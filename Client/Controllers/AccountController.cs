using Api.Models;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AccountController : BaseController<Accounts, AccountRepository, int>
    {
        private readonly AccountRepository repository;
        public AccountController(AccountRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}