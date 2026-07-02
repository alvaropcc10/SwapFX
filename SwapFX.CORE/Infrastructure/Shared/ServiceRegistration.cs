using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Core.Settings;
namespace SwapFX.CORE.Infrastructure.Shared;
public static class ServiceRegistration
{
    public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<JWTSettings>(config.GetSection("JWTSettings"));
        services.AddTransient<IJWTService, JWTService>();
        var issuer = config["JWTSettings:Issuer"];
        var audience = config["JWTSettings:Audience"];
        var secretKey = config["JWTSettings:SecretKey"];
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o => {
            o.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
            };
        });
    }
}
