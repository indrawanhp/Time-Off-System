using Api.Models;
using Client.Base;

namespace Client.Repositories.Data;

public class EmployeeRepository : GeneralRepository<Employee, int>
{
    private readonly Address address;
    private readonly HttpClient httpClient;
    private readonly string request;
    private readonly IHttpContextAccessor _contextAccessor;
    public EmployeeRepository(Address address, string request = "Employee/") : base(address, request)
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
