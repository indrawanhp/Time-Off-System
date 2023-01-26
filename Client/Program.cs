using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);//set 10 menit
});

builder.Services.AddTransient<AccountRepository>();
builder.Services.AddTransient<AuthenticationRepository>();
builder.Services.AddTransient<AccountRoleRepository>();
builder.Services.AddTransient<AllocationLeaveRepository>();
builder.Services.AddTransient<DepartmentRepository>();
builder.Services.AddTransient<EmployeeRepository>();
builder.Services.AddTransient<JobPlacementRepository>();
builder.Services.AddTransient<JobRepository>();
builder.Services.AddTransient<RequestTimeOffRepository>();
builder.Services.AddTransient<RoleRepository>();
builder.Services.AddTransient<Address>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//This is to configuration JWT
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        //Usually, this is your application base URL
        ValidAudience = builder.Configuration["Jwt:Audience"],
        //If the JWT is created using a web service, then this would be the consumer URL.
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.Use(async (context, next) =>
{
    var JWToken = context.Session.GetString("JWToken");
    if (!string.IsNullOrEmpty(JWToken))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
    }
    await next();
});
// Custome Error page
app.UseStatusCodePages(async context => {
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;

    if (response.StatusCode.Equals((int)HttpStatusCode.Unauthorized))
    {
        response.Redirect("/Unauthorized");
    }
    else if (response.StatusCode.Equals((int)HttpStatusCode.NotFound))
    {
        response.Redirect("/NotFound");
    }
    else if (response.StatusCode.Equals((int)HttpStatusCode.Forbidden))
    {
        response.Redirect("/Forbidden");
    }
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
