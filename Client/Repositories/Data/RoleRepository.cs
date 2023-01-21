using Api.Models;
using Client.Base;

namespace Client.Repositories.Data;

public class RoleRepository : GeneralRepository<Roles, int>
{
    private readonly Address address;
    private readonly HttpClient httpClient;
    private readonly string request;
    private readonly IHttpContextAccessor _contextAccessor;
    public RoleRepository(Address address, string request = "Roles/") : base(address, request)
    {
        this.address = address;
        this.request = request;
        _contextAccessor = new HttpContextAccessor();
        httpClient = new HttpClient
        {
            BaseAddress = new Uri(address.link)
        };
    }
}
