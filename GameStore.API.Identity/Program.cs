using Application;
using Persistance;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
                            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                            .Build(); ;

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddDataBase(configuration.GetConnectionString("IdentityDb"));
builder.Services.AddRepositories();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();