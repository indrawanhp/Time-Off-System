using Api.Models;
using Api.ViewModels.Employee;
using Client.Base;
using Newtonsoft.Json;

namespace Client.Repositories.Data;

public class EmployeeRepository : GeneralRepository<Employee, int>
{
    private readonly Address address;
    private readonly HttpClient httpClient;
    private readonly string request;
    private readonly IHttpContextAccessor _contextAccessor;
    public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
    {
        this.address = address;
        this.request = request;
        _contextAccessor = new HttpContextAccessor();
        httpClient = new HttpClient
        {
            BaseAddress = new Uri(address.link)
        };
    }

    //public List<EmployeeRequestVM> GetRequestEmployee(int id, Status status)
    //{
    //    var token = _contextAccessor.HttpContext.Session.GetString("JWToken");
    //    if (token != null)
    //    {
    //        var client = new HttpClient();
    //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //        var result = httpClient.GetAsync(request + "GetRequestEmployee/" + id + "/" + status).Result;
    //        if (result.IsSuccessStatusCode)
    //        {
    //            var apiResponse = result.Content.ReadAsStringAsync().Result;
    //            var data = JsonConvert.DeserializeObject<List<EmployeeRequestVM>>(apiResponse);
    //            return data;
    //        }
    //    }
    //    return null;
    //}
    public async Task<List<EmployeeRequestVM>> GetRequestEmployee(int id, Status status)
    {
        List<EmployeeRequestVM> entity = new List<EmployeeRequestVM>();
        using (var response = await httpClient.GetAsync(request + "GetRequestEmployee/" + id + "/" + status))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<List<EmployeeRequestVM>>(apiResponse);
        }
        return entity;
    }
    public async Task<List<EmployeeRequestVM>> GetRequestManager(int id, Status status)
    {
        List<EmployeeRequestVM> entity = new List<EmployeeRequestVM>();
        using (var response = await httpClient.GetAsync(request + "GetRequestManager/" + id + "/" + status))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<List<EmployeeRequestVM>>(apiResponse);
        }
        return entity;
    }
}
