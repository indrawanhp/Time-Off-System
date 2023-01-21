using Api.Models;

namespace Api.ViewModels;

public class RegisterVM
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Address { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public int Manager { get; set; }
    public int DepartmenId { get; set; }
    public int JobId { get; set; }
}
