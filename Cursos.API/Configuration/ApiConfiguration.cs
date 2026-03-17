using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Cursos.API.Configuration;

public static class ApiConfiguration
{
    public static void ApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = Encoding.ASCII.GetBytes(configuration["JwtConfiguration:Secret"]);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secret),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}