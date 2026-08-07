using JwtAuthentication.Infrastructure;
using JwtAuthentication.Infrastructure.Identity;
using JwtAuthentication.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Register MVC Controllers
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


// Register Entity Framework Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Register Data Protection services required by Identity token providers
builder.Services.AddDataProtection();//todo: check if this is required for Identity token providers


// Register ASP.NET Core Identity
builder.Services
    .AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole<Guid>>()//todo :
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


// Register Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();


// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    // Development-only middleware
}


// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();


// Enable Authentication & Authorization
app.UseAuthorization();


// Map Controller endpoints
app.MapControllers();


// Start application
app.Run();