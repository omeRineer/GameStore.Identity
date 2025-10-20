using Application;
using Persistance;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
                            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                            .Build(); ;

builder.Services.AddAutoMapper(opt =>
{
    opt.AddGlobalIgnore("CreateDate");
    opt.AddGlobalIgnore("EditDate");
}, Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddAuthServer();
builder.Services.AddDataBase(configuration.GetConnectionString("IdentityDb"));
builder.Services.AddRepositories();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthentication();

app.UseAuthorization();

app.Run();