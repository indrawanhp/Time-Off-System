using Api.Models;
using Client.Base;
using Newtonsoft.Json;

namespace Client.Repositories.Data;

public class AccountRepository : GeneralRepository<Accounts, int>
{
    private readonly Address address;
    private readonly HttpClient httpClient;
    private readonly string request;
    private readonly IHttpContextAccessor _contextAccessor;
    public AccountRepository(Address address, string request = "Accounts/") : base(address, request)
    {
        this.address = address;
        this.request = request;
        _contextAccessor = new HttpContextAccessor();
        httpClient = new HttpClient
        {
            BaseAddress = new Uri(address.link)
        };
    }
    /*public async Task<List<Accounts>> GetRequestAccounts()
    {
        List<Accounts> entity = new List<Accounts>();
        using (var response = await httpClient.GetAsync(request + "GetRequestAccounts/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<List<Accounts>>(apiResponse);
        }
        return entity;
    }*/
}
