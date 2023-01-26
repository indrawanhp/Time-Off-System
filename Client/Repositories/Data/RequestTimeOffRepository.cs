using Api.Models;
using Client.Base;
using Newtonsoft.Json;
using System.Security.Cryptography;

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

    public async Task<RequestTimeOff> GetById(int id)
    {
        RequestTimeOff entity = null;
        using (var response = await httpClient.GetAsync(request + id))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<RequestTimeOff>(apiResponse);
        }
        return entity;
    }
}
