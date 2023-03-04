# How to code our very own _ASP.Net Core Web Api_
# Step-by-Step

## Create Solution

- ProjectName: Solution.WebApi
- SolutionName: Solution
- ASP.NET Core Web Api
        - Framework: .NET 6.0 / .NET 7.0
        - Authentication type: None
        - HTTPS
        - Use controllers
        - Enable OpenApi support
- Delete WeatherForecast.cs and Controllers/WeatherForecastController.cs
 

## Configure Database
- Install the necessary NuGet packages:
            **1. Microsoft.EntityFrameworkCore.Tools
            2. Microsoft.EntityFrameworkCore.SqlServer**
- Make your app's **DbContext which inherites from DbContext**
- Don't forget to create its constructor with base options
```cs
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
```
- Specify your connectionString in appsettings.json
```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost;Database=FunRaiseDB;User Id=sa;Password=Password123!;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
  }
```
- Add the service to the Program.cs container
```cs
string connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("The Default ConnectionString is missing.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
```
- Write **Add-Migration InitialCreate** into package manager console
- Setup database before startup in Program.cs before app.Run
```cs
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
{
    await context.Database.MigrateAsync();
}
```
- **Before** startup don't forget to **start Docker**!

**If you make an entity, don't forget to add its DbSet into ApplicationDbContext and also add a migration step!**
**Add-Migration NewEntityName**

## AuthNZ

These steps are optional and they loosely based on: https://www.endpointdev.com/blog/2022/06/implementing-authentication-in-asp.net-core-web-apis/

- Install the necessary NuGet packages
            **1. Microsoft.AspNetCore.Identity
            2. Microsoft.AspNetCore.Identity.EntityFrameworkCore**
 
- Instead of DbContext, your ApplicationDbContext class should inherit from **IdentityUserContext<IdentityUser>**
- Make the DbContext's constructor with the base options for Migration purposes.
```cs
public class ApplicationDbContext : IdentityUserContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
```
- If you want to add additional properties to the generated User entity, make Models/ApplicationUser.cs, which inherites from IdentityUser
```cs
public class ApplicationUser : IdentityUser
{
    [Required]
    public string Goal { get; set; } = string.Empty;

    public decimal Balance { get; set; }
}
```
- Then your ApplicationDbContext will be look like this:
```cs
public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
```
- Add services into Program.cs
```cs
builder.Services.AddIdentityCore<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();
```
- Make an UsersController

