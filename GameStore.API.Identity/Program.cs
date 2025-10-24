using Application;
using Application.Extensions;
using Configuration;
using Persistance;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder.AllowAnyHeader()
                                           .AllowAnyMethod()
                                           .AllowAnyOrigin());
});
builder.Services.AddAutoMapper(opt =>
{
    opt.AddGlobalIgnore("CreateDate");
    opt.AddGlobalIgnore("EditDate");
}, Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddTokenService();
builder.Services.AddDataBase(IdentityConfiguration.ConnectionString);
builder.Services.AddRepositories();

var app = builder.Build();

app.UseStaticServiceProvider();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();