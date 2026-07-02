using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Settings;
namespace SwapFX.CORE.Core.Interfaces;
public interface IJWTService
{
    JWTSettings _settings { get; }
    string GenerateJWToken(Usuario usuario);
}
