using JWT_TokenBased;
using JWT_TokenBased.Helper.Utils;
using JWT_TokenBased.Middleware;
using JWT_TokenBased.Services.LoginDetailsService;
using JWT_TokenBased.Services.StoryService;
using JWT_TokenBased.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

GlobalAttributes.mysqlConfiguration.connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



// Add Application Db Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseJwtMiddleware();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
