using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Core.Settings;
namespace SwapFX.CORE.Infrastructure.Shared;
public class JWTService : IJWTService
{
    public JWTSettings _settings { get; }
    public JWTService(IOptions<JWTSettings> settings)
    {
        _settings = settings.Value;
    }
    public string GenerateJWToken(Usuario usuario)
    {
        var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
        var header = new JwtHeader(sc);
        var claims = new[] {
            new Claim(ClaimTypes.Name, (usuario.Nombres + " " + usuario.Apellidos)),
            new Claim(ClaimTypes.GivenName, usuario.Nombres ?? ""),
            new Claim(ClaimTypes.Email, usuario.Email ?? ""),
            new Claim(ClaimTypes.Role, usuario.Tipo == "A" ? "Admin" : "User"),
            new Claim("UsuarioId", usuario.Id.ToString()),
        };
        var payload = new JwtPayload(
            _settings.Issuer, _settings.Audience, claims,
            DateTime.UtcNow, DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));
        var token = new JwtSecurityToken(header, payload);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
