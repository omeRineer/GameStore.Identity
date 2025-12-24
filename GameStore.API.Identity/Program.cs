using Application;
using Application.Extensions;
using Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder.AllowAnyHeader()
                                           .AllowAnyMethod()
                                           .AllowAnyOrigin());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(opt =>
                            {
                                opt.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,

                                    ValidIssuer = IdentityConfiguration.TokenOptions.Issuer,
                                    ValidAudience = IdentityConfiguration.TokenOptions.Audience,
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IdentityConfiguration.TokenOptions.SecurityKey))

                                };
                            });
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