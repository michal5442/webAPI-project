

using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(option => option.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=Shop_215804253;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
