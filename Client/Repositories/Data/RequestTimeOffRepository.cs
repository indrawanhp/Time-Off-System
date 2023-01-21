using Api.Models;
using Client.Base;

namespace Client.Repositories.Data;

public class RequestTimeOffRepository : GeneralRepository<RequestTimeOff, int>
{
    private readonly Address address;
    private readonly HttpClient httpClient;
    private readonly string request;
    private readonly IHttpContextAccessor _contextAccessor;
    public RequestTimeOffRepository(Address address, string request = "RequestTimeOffs/") : base(address, request)
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
