using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Contexts;

public class MyContext : DbContext
{
	public MyContext(DbContextOptions<MyContext> options) : base(options)
	{

	}

    //Introduce the model to become an Entity
    public DbSet<AccountRoles> AccountRoles { get; set; }
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<AllocationLeave> AllocationsLeave { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobPlacements> JobPlacements { get; set; }
    public DbSet<Jobs> Jobs { get; set; }
    public DbSet<RequestTimeOff> RequestTimeOffs { get; set; }
    public DbSet<Roles> Roles { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Employee>().HasAlternateKey(e => e.Phone);
    }
}
