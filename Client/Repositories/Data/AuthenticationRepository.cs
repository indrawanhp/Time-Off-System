using Api.ViewModels;
using Api.Models;
using Client.Base;
using Client.Models;
using Newtonsoft.Json;
using System.Text;


namespace Client.Repositories.Data;

public class AuthenticationRepository : GeneralRepository<Accounts, int>
{ 
    private readonly Address address;
    private readonly HttpClient httpClient;
    private readonly string request;
    private readonly IHttpContextAccessor _contextAccessor;
    public AuthenticationRepository(Address address, string request = "Account/") : base(address, request)
    {
        this.address = address;
        this.request = request;
        _contextAccessor = new HttpContextAccessor();
        httpClient = new HttpClient
        {
            BaseAddress = new Uri(address.link)
        };
    }
    public async Task<JWTokenVM> Auth(LoginVM login)
    {
        JWTokenVM token = null;

        StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
        var result = await httpClient.PostAsync(request + "Login/", content);

        string apiResponse = await result.Content.ReadAsStringAsync();
        token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);

        return token;
    }
}
